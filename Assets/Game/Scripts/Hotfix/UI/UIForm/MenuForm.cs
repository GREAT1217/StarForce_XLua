using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class MenuForm : LuaForm
    {
        private GameObject m_QuitButton = null;

        private ProcedureMenu m_ProcedureMenu = null;

        public void OnStartButtonClick()
        {
            m_ProcedureMenu.StartGame();
        }

        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
        }

        public void OnAboutButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.AboutForm);
        }

        public void OnQuitButtonClick()
        {
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = GameEntry.Localization.GetString("AskQuitGame.Title"),
                Message = GameEntry.Localization.GetString("AskQuitGame.Message"),
                OnClickConfirm = delegate(object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            });
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);

            ReferenceCollector collector = HotfixForm.ReferenceCollector;
            m_QuitButton = collector.GetGO("bt_Quit");
            (m_QuitButton.GetComponent(typeof(CommonButton)) as CommonButton).OnClick.AddListener(OnQuitButtonClick);
            m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
            (collector.Get("bt_About", typeof(CommonButton)) as CommonButton).OnClick.AddListener(OnAboutButtonClick);
            (collector.Get("bt_Setting", typeof(CommonButton)) as CommonButton).OnClick.AddListener(OnSettingButtonClick);
            (collector.Get("bt_Start", typeof(CommonButton)) as CommonButton).OnClick.AddListener(OnStartButtonClick);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            HotfixUserData data = userData as HotfixUserData;
            if (data == null)
            {
                Log.Error("HotfixForm open failed.");
                return;
            }

            m_ProcedureMenu = (ProcedureMenu)data.UserData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }

            m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(bool isShutdown, object userData)
#else
        protected internal override void OnClose(bool isShutdown, object userData)
#endif
        {
            m_ProcedureMenu = null;

            base.OnClose(isShutdown, userData);
        }
    }
}
