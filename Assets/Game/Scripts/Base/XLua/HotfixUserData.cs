using GameFramework;

namespace Game
{
    /// <summary>
    /// 自定义的底层与热更层传递的数据。
    /// </summary>
    public sealed class HotfixUserData
    {
        /// <summary>
        /// 热更逻辑类型名。
        /// </summary>
        public string HotfixTypeName
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
        public object HotfixLogic
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义的底层与热更层传递的数据。
        /// </summary>
        /// <param name="hotLogicTypeName">热更逻辑类型名。</param>
        /// <param name="userData">用户自定义数据。</param>
        public HotfixUserData(string hotLogicTypeName, object userData)
        {
            HotfixTypeName = hotLogicTypeName;
            UserData = userData;
        }
    }
}
