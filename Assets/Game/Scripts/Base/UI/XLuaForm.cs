using GameExtension;
using XLua;

namespace Game
{
    public class XLuaForm : UGuiForm
    {
        // 热更新层的方法缓存。
        private LuaFunction m_OnRecycle;
        private LuaFunction m_OnOpen;
        private LuaFunction m_OnClose;
        private LuaFunction m_OnPause;
        private LuaFunction m_OnResume;
        private LuaFunction m_OnCover;
        private LuaFunction m_OnReveal;
        private LuaFunction m_OnRefocus;
        private LuaFunction m_OnUpdate;
        private LuaFunction m_OnDepthChanged;

        /// <summary>
        /// 热更新层的界面实例。
        /// </summary>
        public LuaTable LuaForm
        {
            get;
            private set;
        }

        public ComponentCollection Components
        {
            get;
            private set;
        }

        protected override void OnInit(object userData)
        {
            XLuaUserData data = userData as XLuaUserData;
            if (data == null)
            {
                return;
            }

            base.OnInit(data.UserData);

            Components = GetComponent<ComponentCollection>();

            // 获取热更新层的实例。
            string tableName = data.LuaScriptName.Substring(data.LuaScriptName.LastIndexOf('/') + 1);
            GameEntry.XLua.DoLuaScript(data.LuaScriptName);
            LuaForm = GameEntry.XLua.GetLuaTable(data.LuaScriptName, tableName);

            // 获取热更新层的方法并缓存。
            m_OnRecycle = GameEntry.XLua.GetLuaFunction(LuaForm, "OnRecycle");
            m_OnOpen = GameEntry.XLua.GetLuaFunction(LuaForm, "OnOpen");
            m_OnClose = GameEntry.XLua.GetLuaFunction(LuaForm, "OnClose");
            m_OnPause = GameEntry.XLua.GetLuaFunction(LuaForm, "OnPause");
            m_OnResume = GameEntry.XLua.GetLuaFunction(LuaForm, "OnResume");
            m_OnCover = GameEntry.XLua.GetLuaFunction(LuaForm, "OnCover");
            m_OnReveal = GameEntry.XLua.GetLuaFunction(LuaForm, "OnReveal");
            m_OnRefocus = GameEntry.XLua.GetLuaFunction(LuaForm, "OnRefocus");
            m_OnUpdate = GameEntry.XLua.GetLuaFunction(LuaForm, "OnUpdate");
            m_OnDepthChanged = GameEntry.XLua.GetLuaFunction(LuaForm, "OnDepthChanged");

            // 调用热更新层的 OnInit()
            data.BaseLogic = this;
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnInit", LuaForm, data); // 传入 LuaForm 用于 LuaForm 调用自身的基类：self.base
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            m_OnRecycle.Call(LuaForm);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_OnOpen.Call(LuaForm, userData);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            m_OnClose.Call(LuaForm, isShutdown, userData);
        }

        protected override void OnPause()
        {
            base.OnPause();
            m_OnPause.Call(LuaForm);
        }

        protected override void OnResume()
        {
            base.OnResume();
            m_OnResume.Call(LuaForm);
        }

        protected override void OnCover()
        {
            base.OnCover();
            m_OnCover.Call(LuaForm);
        }

        protected override void OnReveal()
        {
            base.OnReveal();
            m_OnReveal.Call(LuaForm);
        }

        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            m_OnRefocus.Call(LuaForm, userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            m_OnUpdate.Call(LuaForm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            m_OnDepthChanged.Call(LuaForm, uiGroupDepth, depthInUIGroup);
        }
    }
}
