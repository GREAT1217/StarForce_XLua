using UnityGameFramework.Runtime;
using XLua;

namespace Game
{
    public static class XLuaLog
    {
        public static void Debug(object message)
        {
            Log.Debug(message);
        }

        public static void Info(object message)
        {
            Log.Info(message);
        }

        public static void Warning(object message)
        {
            Log.Warning(message);
        }

        public static void Error(object message)
        {
            Log.Error(message);
        }
    }
}
