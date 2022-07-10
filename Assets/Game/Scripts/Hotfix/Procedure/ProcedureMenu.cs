using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class ProcedureMenu : HotfixProcedure
    {
        private bool m_StartGame = false;
        private HotfixForm m_MenuForm = null;

        public void StartGame()
        {
            m_StartGame = true;
        }

        public override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            m_StartGame = false;
            GameEntry.UI.OpenHotfixUIForm(HotfixUIFormId.MenuForm, this);
        }

        public override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (m_MenuForm != null && m_MenuForm.Visible)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }
        }

        public override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_StartGame)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
                procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Survival);
                GameHotfixEntry.ChangeHotfixProcedure<ProcedureChangeScene>(procedureOwner);
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            HotfixUserData userData = ne.UserData as HotfixUserData;
            if (userData == null || userData.UserData != this)
            {
                return;
            }

            m_MenuForm = userData.HotfixLogic as HotfixForm;
        }
    }
}
