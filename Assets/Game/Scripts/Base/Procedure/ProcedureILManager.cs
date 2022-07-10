// using System;
// using System.Collections.Generic;
// using GameFramework.Fsm;
// using GameFramework.Procedure;
// using UnityGameFramework.Runtime;
//
// namespace Game
// {
//     public class ProcedureILManager : ProcedureBase
//     {
//         private bool m_ChangeProcedure;
//         private Type m_ProcedureType;
//
//         private Dictionary<string, ProcedureILBase> m_HotfixProcedures = new Dictionary<string, ProcedureILBase>();
//         private ProcedureILBase m_CurrentHotfixBase;
//
//         protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
//         {
//             base.OnEnter(procedureOwner);
//
//             GameEntry.ILRuntime.StartHotfix(this);
//         }
//
//         protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
//         {
//             base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
//
//             GameEntry.ILRuntime.UpdateHotfix(elapseSeconds, realElapseSeconds);
//
//             if (m_CurrentHotfixBase != null)
//             {
//                 m_CurrentHotfixBase.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
//             }
//
//             if (m_ChangeProcedure)
//             {
//                 if (m_CurrentHotfixBase != null)
//                 {
//                     m_CurrentHotfixBase.OnLeave(procedureOwner, false);
//                     m_CurrentHotfixBase = null;
//                 }
//                 ChangeState(procedureOwner, m_ProcedureType);
//             }
//         }
//
//         protected override void OnDestroy(IFsm<IProcedureManager> procedureOwner)
//         {
//             base.OnDestroy(procedureOwner);
//
//             GameEntry.ILRuntime.DestroyHotfix();
//
//             foreach (var hotfixProcedure in m_HotfixProcedures.Values)
//             {
//                 hotfixProcedure.OnDestroy(procedureOwner);
//             }
//         }
//
//         public void StartHotfixProcedure(string hotfixTypeName)
//         {
//             IFsm<IProcedureManager> procedureOwner = GameEntry.Fsm.GetFsm<IProcedureManager>();
//             ChangeHotfixProcedure(procedureOwner, hotfixTypeName);
//         }
//
//         public void ChangeHotfixProcedure(IFsm<IProcedureManager> procedureOwner, string hotfixTypeName)
//         {
//             if (m_CurrentHotfixBase != null)
//             {
//                 m_CurrentHotfixBase.OnLeave(procedureOwner, false);
//                 m_CurrentHotfixBase = null;
//             }
//
//             if (!m_HotfixProcedures.TryGetValue(hotfixTypeName, out ProcedureILBase procedure))
//             {
//                 procedure = new ProcedureILBase(hotfixTypeName);
//                 procedure.OnInit(procedureOwner);
//                 m_HotfixProcedures.Add(hotfixTypeName, procedure);
//             }
//
//             procedure.OnEnter(procedureOwner);
//             m_CurrentHotfixBase = procedure;
//         }
//
//         public void ChangeProcedure<T>(IFsm<IProcedureManager> procedureOwner) where T : ProcedureBase
//         {
//             m_ProcedureType = typeof(T);
//             m_ChangeProcedure = true;
//         }
//     }
// }
