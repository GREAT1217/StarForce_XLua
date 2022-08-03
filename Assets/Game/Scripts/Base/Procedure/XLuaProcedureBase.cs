using System;
using GameFramework.Fsm;
using GameFramework.Procedure;
using XLua;

namespace Game
{
    [LuaCallCSharp]
    public class XLuaProcedureBase
    {
        // 热更新层的方法缓存。
        private LuaFunction m_OnInit;
        private LuaFunction m_OnEnter;
        private LuaFunction m_OnUpdate;
        private LuaFunction m_OnLeave;
        private LuaFunction m_OnDestroy;

        /// <summary>
        /// 热更新的流程实例。
        /// </summary>
        public LuaTable LuaProcedure
        {
            get;
            private set;
        }

        public XLuaProcedureBase(string hotfixTypeName)
        {
            // 获取热更新层的实例。
            string tableName = hotfixTypeName.Substring(hotfixTypeName.LastIndexOf('/') + 1);
            GameEntry.XLua.DoLuaScript(hotfixTypeName);
            LuaProcedure = GameEntry.XLua.GetLuaTable(hotfixTypeName, tableName);

            // 获取热更新层的方法并缓存。
            m_OnInit = GameEntry.XLua.GetLuaFunction(LuaProcedure, "OnInit");
            m_OnEnter = GameEntry.XLua.GetLuaFunction(LuaProcedure, "OnEnter");
            m_OnUpdate = GameEntry.XLua.GetLuaFunction(LuaProcedure, "OnUpdate");
            m_OnLeave = GameEntry.XLua.GetLuaFunction(LuaProcedure, "OnLeave");
            m_OnDestroy = GameEntry.XLua.GetLuaFunction(LuaProcedure, "OnDestroy");
        }

        public void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            m_OnInit.Call(LuaProcedure, procedureOwner);
        }

        public void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            m_OnEnter.Call(LuaProcedure, procedureOwner);
        }

        public void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            m_OnUpdate.Call(LuaProcedure, procedureOwner, elapseSeconds, realElapseSeconds);
        }

        public void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            m_OnLeave.Call(LuaProcedure, procedureOwner, isShutdown);
        }

        public void OnDestroy(IFsm<IProcedureManager> procedureOwner)
        {
            m_OnDestroy.Call(LuaProcedure, procedureOwner);
        }
    }
}
