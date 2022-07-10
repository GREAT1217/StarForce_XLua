using XLua;

namespace Game
{
    public class HotfixForm : UGuiForm
    {
        // 热更新层的方法缓存。
        // private LuaTable m_OnRecycle;
        // private LuaTable m_OnOpen;
        // private LuaTable m_OnClose;
        // private LuaTable m_OnPause;
        // private LuaTable m_OnResume;
        // private LuaTable m_OnCover;
        // private LuaTable m_OnReveal;
        // private LuaTable m_OnRefocus;
        // private LuaTable m_OnUpdate;
        // private LuaTable m_OnDepthChanged;

        /// <summary>
        /// 热更新层的界面实例。
        /// </summary>
        public LuaTable LuaForm
        {
            get;
            private set;
        }

        public ReferenceCollector ReferenceCollector
        {
            get;
            private set;
        }

        protected override void OnInit(object userData)
        {
            HotfixUserData data = userData as HotfixUserData;
            if (data == null)
            {
                return;
            }

            base.OnInit(data.UserData);

            ReferenceCollector = GetComponent<ReferenceCollector>();

            // 获取热更新层的实例。
            string luaName = data.HotfixTypeName;
            GameEntry.XLua.DoLuaScript(luaName);
            LuaForm = GameEntry.XLua.GetLuaTable(luaName, Name);

            // Action luaAwake = scriptEnv.Get<Action>("awake");
            // scriptEnv.Get("start", out luaStart);
            // scriptEnv.Get("update", out luaUpdate);
            // scriptEnv.Get("ondestroy", out luaOnDestroy);

            // 获取热更新层的方法并缓存。
            // m_OnRecycle = GameEntry.XLua.GetLuaTable(HotfixForm, "OnRecycle");
            // m_OnOpen = GameEntry.XLua.GetLuaTable(HotfixForm, "OnOpen");
            // m_OnClose = GameEntry.XLua.GetLuaTable(HotfixForm, "OnClose");
            // m_OnPause = GameEntry.XLua.GetLuaTable(HotfixForm, "OnPause");
            // m_OnResume = GameEntry.XLua.GetLuaTable(HotfixForm, "OnResume");
            // m_OnCover = GameEntry.XLua.GetLuaTable(HotfixForm, "OnCover");
            // m_OnReveal = GameEntry.XLua.GetLuaTable(HotfixForm, "OnReveal");
            // m_OnRefocus = GameEntry.XLua.GetLuaTable(HotfixForm, "OnRefocus");
            // m_OnUpdate = GameEntry.XLua.GetLuaTable(HotfixForm, "OnUpdate");
            // m_OnDepthChanged = GameEntry.XLua.GetLuaTable(HotfixForm, "OnDepthChanged");

            // 调用热更新层的 OnInit()
            data.HotfixLogic = this;
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnInit", data);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnRecycle");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnOpen", userData);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnClose", isShutdown, userData);
        }

        protected override void OnPause()
        {
            base.OnPause();
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnPause");
        }

        protected override void OnResume()
        {
            base.OnResume();
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnResume");
        }

        protected override void OnCover()
        {
            base.OnCover();
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnCover");
        }

        protected override void OnReveal()
        {
            base.OnReveal();
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnReveal");
        }

        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnRefocus", userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnUpdate", elapseSeconds, realElapseSeconds);
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            GameEntry.XLua.InvokeLuaFunction(LuaForm, "OnDepthChanged", uiGroupDepth, depthInUIGroup);
        }
    }
}
