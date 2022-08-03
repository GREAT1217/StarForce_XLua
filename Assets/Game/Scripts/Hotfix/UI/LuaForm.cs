using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public abstract class LuaForm
    {
        /// <summary>
        /// 底层界面逻辑。
        /// </summary>
        protected XLuaForm XLuaForm
        {
            get;
            private set;
        }

        public void Close()
        {
            XLuaForm.Close(false);
        }

        public void Close(bool ignoreFade)
        {
            XLuaForm.Close(ignoreFade);
        }

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected virtual void OnInit(object userData)
        {
            HotfixUserData data = userData as HotfixUserData;
            if (data == null)
            {
                Log.Error("ILForm data is invalid.");
                return;
            }

            XLuaForm = data.HotfixLogic as XLuaForm;
        }

        /// <summary>
        /// 界面回收。
        /// </summary>
        protected virtual void OnRecycle()
        {
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected virtual void OnOpen(object userData)
        {
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected virtual void OnClose(bool isShutdown, object userData)
        {
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected virtual void OnCover()
        {
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected virtual void OnReveal()
        {
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected virtual void OnRefocus(object userData)
        {
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected virtual void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
        }
    }
}
