/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
    /// <summary>
    /// 属性变更事件参数。
    /// </summary>
    public class PropertyChangedEventArgs : EventArgs
    {
        public string name;
        public object value;
    }

    public class InvokeLua : MonoBehaviour
    {
        /// <summary>
        /// 计算接口
        /// </summary>
        [CSharpCallLua]
        public interface ICalc
        {
            /// <summary>
            /// 属性变更事件
            /// </summary>
            event EventHandler<PropertyChangedEventArgs> PropertyChanged;

            /// <summary>
            /// 加
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            int Add(int a, int b);

            /// <summary>
            /// 倍数
            /// </summary>
            int Mult
            {
                get;
                set;
            }

            /// <summary>
            /// 索引器
            /// </summary>
            /// <param name="index"></param>
            object this[int index]
            {
                get;
                set;
            }
        }

        /// <summary>
        /// 计算委托
        /// </summary>
        [CSharpCallLua]
        public delegate ICalc CalcNew(int mult, params string[] args);

        public TextAsset luaScript;

        void Start()
        {
            LuaEnv luaenv = new LuaEnv();
            Test(luaenv); //调用了带可变参数的delegate，函数结束都不会释放delegate，即使置空并调用GC
            luaenv.Dispose();
        }

        void Test(LuaEnv luaenv)
        {
            luaenv.DoString(luaScript.text);
            CalcNew calc_new = luaenv.Global.GetInPath<CalcNew>("Calc.New");
            ICalc calc = calc_new(10, "hi", "john"); // constructor
            Debug.Log("sum(*10) =" + calc.Add(1, 2)); // 30
            calc.Mult = 100;
            Debug.Log("sum(*100)=" + calc.Add(1, 2)); // 300

            Debug.Log("list[0]=" + calc[0]); // aaaa
            Debug.Log("list[1]=" + calc[1]); // bbbb

            calc.PropertyChanged += Notify; // add Notify
            calc[1] = "dddd";
            Debug.Log("list[1]=" + calc[1]); // dddd

            calc.PropertyChanged -= Notify; // remove Notify

            calc[1] = "eeee";
            Debug.Log("list[1]=" + calc[1]); // eeee
        }

        void Notify(object sender, PropertyChangedEventArgs e)
        {
            Debug.Log(string.Format("{0} has property changed {1}={2}", sender, e.name, e.value));
        }
    }
}
