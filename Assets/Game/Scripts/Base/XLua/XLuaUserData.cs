namespace Game
{
    /// <summary>
    /// 自定义的底层与热更层传递的数据。
    /// </summary>
    public sealed class XLuaUserData
    {
        /// <summary>
        /// 热更逻辑类型名。
        /// </summary>
        public string LuaScriptName
        {
            get;
        }

        /// <summary>
        /// 用户自定义数据。
        /// </summary>
        public object UserData
        {
            get;
        }

        /// <summary>
        /// 底层逻辑实例。
        /// </summary>
        public object BaseLogic
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义的底层与热更层传递的数据。
        /// </summary>
        /// <param name="luaScriptName">热更逻辑类型名。</param>
        /// <param name="userData">用户自定义数据。</param>
        public XLuaUserData(string luaScriptName, object userData)
        {
            LuaScriptName = luaScriptName;
            UserData = userData;
        }
    }
}
