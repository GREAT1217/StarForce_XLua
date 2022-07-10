// using GameFramework.Fsm;
// using GameFramework.Procedure;
// using ILRuntime.CLR.TypeSystem;
// using UnityGameFramework.Runtime;
//
// namespace Game
// {
//     public class ProcedureILBase
//     {
//         // 热更新层的方法缓存。
//         private ILInstanceMethod m_OnInit;
//         private ILInstanceMethod m_OnEnter;
//         private ILInstanceMethod m_OnUpdate;
//         private ILInstanceMethod m_OnLeave;
//         private ILInstanceMethod m_OnDestroy;
//
//         /// <summary>
//         /// 热更新的流程实例。
//         /// </summary>
//         public object HotfixProcedure
//         {
//             get;
//             set;
//         }
//
//         public ProcedureILBase()
//         {
//         }
//
//         public ProcedureILBase(string hotfixTypeName)
//         {
//             // 获取热更新层的实例。
//             IType type = GameEntry.ILRuntime.AppDomain.LoadedTypes[hotfixTypeName];
//             HotfixProcedure = ((ILType)type).Instantiate();
//
//             // 获取热更新层的方法并缓存。
//             m_OnInit = new ILInstanceMethod(HotfixProcedure, hotfixTypeName, "OnInit", 1);
//             m_OnEnter = new ILInstanceMethod(HotfixProcedure, hotfixTypeName, "OnEnter", 1);
//             m_OnUpdate = new ILInstanceMethod(HotfixProcedure, hotfixTypeName, "OnUpdate", 3);
//             m_OnLeave = new ILInstanceMethod(HotfixProcedure, hotfixTypeName, "OnLeave", 2);
//             m_OnDestroy = new ILInstanceMethod(HotfixProcedure, hotfixTypeName, "OnDestroy", 1);
//         }
//
//         public void OnInit(IFsm<IProcedureManager> procedureOwner)
//         {
//             m_OnInit.Invoke(procedureOwner);
//         }
//
//         public void OnEnter(IFsm<IProcedureManager> procedureOwner)
//         {
//             m_OnEnter.Invoke(procedureOwner);
//         }
//
//         public void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
//         {
//             m_OnUpdate.Invoke(procedureOwner, elapseSeconds, realElapseSeconds);
//         }
//
//         public void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
//         {
//             m_OnLeave.Invoke(procedureOwner, isShutdown);
//         }
//
//         public void OnDestroy(IFsm<IProcedureManager> procedureOwner)
//         {
//             m_OnDestroy.Invoke(procedureOwner);
//         }
//     }
// }
