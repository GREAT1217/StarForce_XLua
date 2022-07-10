using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class ProcedureStart : HotfixProcedure
    {
        public override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            
            // 切换流程一定要在 OnUpdate 中切换
            procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Menu"));
            GameHotfixEntry.ChangeHotfixProcedure<ProcedureChangeScene>(procedureOwner);
        }
    }
}
