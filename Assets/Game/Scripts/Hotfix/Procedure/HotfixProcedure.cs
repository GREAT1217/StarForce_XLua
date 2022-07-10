using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public abstract class HotfixProcedure
    {
        public virtual void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
        }

        public virtual void OnDestroy(IFsm<IProcedureManager> procedureOwner)
        {
        }

        public virtual void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
        }

        public virtual void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
        }

        public virtual void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}
