using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public static class HotfixUIExtension
    {
        public static int? OpenHotfixUIForm(this UIComponent uiComponent, HotfixUIFormId uiFormId, object userData = null)
        {
            HotfixUserData data = new HotfixUserData("Game.Hotfix." + uiFormId.ToString(), userData);
            return uiComponent.OpenUIForm((int)uiFormId, data);
        }
    }
}
