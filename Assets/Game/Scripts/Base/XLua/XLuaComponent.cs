using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using XLua;

namespace Game
{
    public class XLuaComponent : GameFrameworkComponent
    {
        private LuaEnv m_LuaEnv;
        private Dictionary<string, string> m_CacheLuaDict;

        private void Start()
        {
            m_LuaEnv = new LuaEnv();
            m_LuaEnv.AddLoader(CustomLoader);
            m_CacheLuaDict = new Dictionary<string, string>();
        }

        /// <summary>
        /// 自定义 Loader，用于 Lua 中 require ("")。
        /// </summary>
        /// <param name="scriptName">脚本名称。</param>
        /// <returns></returns>
        private byte[] CustomLoader(ref string scriptName)
        {
            if (m_CacheLuaDict.TryGetValue(scriptName, out string script))
            {
                return System.Text.Encoding.UTF8.GetBytes(script);
            }

            Log.Warning("require scriptName '{0}' is not exits.", scriptName);
            return null;
        }

        private void Update()
        {
            if (m_LuaEnv != null)
            {
                m_LuaEnv.Tick();
            }
        }

        private void OnDestroy()
        {
            if (m_LuaEnv != null)
            {
                m_LuaEnv.Dispose();
                m_LuaEnv = null;
            }
        }

        public void CacheLuaScripts(string luaScriptName, string luaScript)
        {
            m_CacheLuaDict.Add(luaScriptName, luaScript);
        }

        public void DoLuaScript(string luaScriptName)
        {
            if (m_CacheLuaDict.TryGetValue(luaScriptName, out string luaScript))
            {
                try
                {
                    if (m_LuaEnv != null)
                    {
                        m_LuaEnv.DoString(luaScript);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            else
            {
                Log.Error("Lua file '{0}' is not load, please execute LoadLuaFile() first.", luaScriptName);
            }
        }

        public LuaTable GetLuaTable(string luaScriptName, string tableName)
        {
            if (m_CacheLuaDict.ContainsKey(luaScriptName))
            {
                return m_LuaEnv.Global.Get<LuaTable>(tableName);
            }

            Log.Error("Lua file '{0}' is not load, please execute LoadLuaFile() first.", luaScriptName);
            return null;
        }

        public LuaFunction GetLuaFunction(LuaTable luaTable, string tableName)
        {
            if (luaTable != null)
            {
                return luaTable.Get<LuaFunction>(tableName);
            }

            Log.Error("Lua table is null, Lua function '{0}' get failed.", tableName);
            return null;
        }

        public void InvokeLuaFunction(LuaTable luaTable, string functionName, params object[] param)
        {
            if (luaTable != null)
            {
                try
                {
                    using (LuaFunction luaFunction = luaTable.Get<LuaFunction>(functionName))
                    {
                        luaFunction.Call(param);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            else
            {
                Log.Error("Lua table is null, Lua function '{0}' invoke failed.", functionName);
            }
        }
    }
}
