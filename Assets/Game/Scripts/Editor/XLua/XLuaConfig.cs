using System;
using System.Collections.Generic;
using System.Reflection;
using XLua;

public static class XLuaConfig
{
    // XLua 用白名单来指明生成哪些代码。无法直接给一个类型打标签，比如系统api，没源码的库，或者实例化的泛化类型，可以使用下面的静态列表实现。

    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>()
    {
        typeof(UnityEngine.Events.UnityAction<bool>),
        typeof(UnityEngine.Events.UnityAction<float>),
    };

    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>()
    {
        typeof(Game.GameEntry),
        typeof(Game.XLuaLog),
        typeof(Game.ComponentCollectionExtension),
        typeof(Game.SoundExtension),
        typeof(Game.UIExtension),
        typeof(Game.XLuaForm),
    };

    // 如果不要生成一个类型的一些成员的适配代码，可以通过配置黑名单来实现。

    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()
    {
        new List<string>() {"System.Xml.XmlNodeList", "ItemOf"},
        new List<string>() {"UnityEngine.WWW", "movie"},
#if UNITY_WEBGL
        new List<string>(){"UnityEngine.WWW", "threadPriority"},
#endif
        new List<string>() {"UnityEngine.Texture2D", "alphaIsTransparency"},
        new List<string>() {"UnityEngine.Security", "GetChainOfTrustValue"},
        new List<string>() {"UnityEngine.CanvasRenderer", "onRequestRebuild"},
        new List<string>() {"UnityEngine.Light", "areaSize"},
        new List<string>() {"UnityEngine.Light", "lightmapBakeType"},
        new List<string>() {"UnityEngine.WWW", "MovieTexture"},
        new List<string>() {"UnityEngine.WWW", "GetMovieTexture"},
        new List<string>() {"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
        new List<string>() {"UnityEngine.Application", "ExternalEval"},
#endif
        new List<string>() {"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
        new List<string>() {"UnityEngine.Component", "networkView"}, //4.6.2 not support
        new List<string>() {"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"UnityEngine.MonoBehaviour", "runInEditMode"},
    };

#if UNITY_2018_1_OR_NEWER
    [BlackList]
    public static Func<MemberInfo, bool> MethodFilter = (memberInfo) =>
    {
        if (memberInfo.DeclaringType.IsGenericType && memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            if (memberInfo.MemberType == MemberTypes.Constructor)
            {
                ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
                var parameterInfos = constructorInfo.GetParameters();
                if (parameterInfos.Length > 0)
                {
                    if (typeof(System.Collections.IEnumerable).IsAssignableFrom(parameterInfos[0].ParameterType))
                    {
                        return true;
                    }
                }
            }
            else if (memberInfo.MemberType == MemberTypes.Method)
            {
                var methodInfo = memberInfo as MethodInfo;
                if (methodInfo.Name == "TryAdd" || methodInfo.Name == "Remove" && methodInfo.GetParameters().Length == 2)
                {
                    return true;
                }
            }
        }
        return false;
    };
#endif
}
