using GameFramework.Fsm;
using GameFramework.Procedure;

namespace Game.Hotfix
{
    public class GameHotfixEntry
    {
        //private static ProcedureILManager m_ProcedureManager;

        public static void Start(object procedureManager)
        {
          //  m_ProcedureManager = (ProcedureILManager)procedureManager;
            //m_ProcedureManager.StartHotfixProcedure(typeof(ProcedureStart).ToString());
            
            // 初始化自定义组件。
            // m_HotfixNode = new GameObject("Hotfix").transform;
            // HPBar = new HPBarManager();
        }

        public static void Update(float elapseSeconds, float realElapseSeconds)
        {
            // HPBar.Update();
        }

        public static void Shutdown()
        {
        }

        
        public static void ChangeHotfixProcedure<T>(IFsm<IProcedureManager> procedureOwner) where T : HotfixProcedure
        {
         //   m_ProcedureManager.ChangeHotfixProcedure(procedureOwner, typeof(T).ToString());
        }

        public static void ChangeProcedure<T>(IFsm<IProcedureManager> procedureOwner) where T : ProcedureBase
        {
           // m_ProcedureManager.ChangeProcedure<T>(procedureOwner);
        }
    }
}
