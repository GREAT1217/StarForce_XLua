using System;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using XLua;

namespace Game
{
    [LuaCallCSharp]
    public class XLuaProcedureManager : ProcedureBase
    {
        private bool m_ChangeProcedure;
        private Type m_NextProcedureType;

        private Dictionary<string, XLuaProcedureBase> m_HotfixProcedures = new Dictionary<string, XLuaProcedureBase>();
        private XLuaProcedureBase m_CurrentXLuaProcedure;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.XLua.StartXLua(this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            GameEntry.XLua.UpdateXLua(elapseSeconds, realElapseSeconds);
            
            if (m_CurrentXLuaProcedure != null)
            {
                m_CurrentXLuaProcedure.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            }
            
            if (m_ChangeProcedure)
            {
                if (m_CurrentXLuaProcedure != null)
                {
                    m_CurrentXLuaProcedure.OnLeave(procedureOwner, false);
                    m_CurrentXLuaProcedure = null;
                }
                ChangeState(procedureOwner, m_NextProcedureType);
            }
        }

        protected override void OnDestroy(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnDestroy(procedureOwner);

            GameEntry.XLua.DestroyXLua();
            
            foreach (var hotfixProcedure in m_HotfixProcedures.Values)
            {
                hotfixProcedure.OnDestroy(procedureOwner);
            }
        }

        public void StartXLuaProcedure(string hotfixTypeName)
        {
            IFsm<IProcedureManager> procedureOwner = GameEntry.Fsm.GetFsm<IProcedureManager>();
            ChangeXLuaProcedure(procedureOwner, hotfixTypeName);
        }

        public void ChangeXLuaProcedure(IFsm<IProcedureManager> procedureOwner, string hotfixTypeName)
        {
            if (m_CurrentXLuaProcedure != null)
            {
                m_CurrentXLuaProcedure.OnLeave(procedureOwner, false);
                m_CurrentXLuaProcedure = null;
            }
            
            if (!m_HotfixProcedures.TryGetValue(hotfixTypeName, out XLuaProcedureBase procedure))
            {
                procedure = new XLuaProcedureBase(hotfixTypeName);
                procedure.OnInit(procedureOwner);
                m_HotfixProcedures.Add(hotfixTypeName, procedure);
            }
            
            procedure.OnEnter(procedureOwner);
            m_CurrentXLuaProcedure = procedure;
        }

        public void ChangeProcedure<T>(IFsm<IProcedureManager> procedureOwner) where T : ProcedureBase
        {
            m_NextProcedureType = typeof(T);
            m_ChangeProcedure = true;
        }
    }
}
