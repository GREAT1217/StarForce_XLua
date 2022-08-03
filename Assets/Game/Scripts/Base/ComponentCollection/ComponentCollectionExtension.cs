//------------------------------------------------------------
// 此文件由 ComponentCollection 自动生成，请勿直接修改。
// 用于在不方便使用非泛型的语言中（如XLua）调用 GetComponent 函数
// 生成时间：2022-08-02 13:50:03.03
//------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using GameExtension;
using XLua;

namespace Game
{
    [LuaCallCSharp]
    public static class ComponentCollectionExtension
    {
        public static RectMask2D GetRectMask2D(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<RectMask2D>(index);
        }

        public static Mask GetMask(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Mask>(index);
        }

        public static HorizontalLayoutGroup GetHorizontalLayoutGroup(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<HorizontalLayoutGroup>(index);
        }

        public static VerticalLayoutGroup GetVerticalLayoutGroup(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<VerticalLayoutGroup>(index);
        }

        public static GridLayoutGroup GetGridLayoutGroup(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<GridLayoutGroup>(index);
        }

        public static CanvasGroup GetCanvasGroup(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<CanvasGroup>(index);
        }

        public static ScrollRect GetScrollRect(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<ScrollRect>(index);
        }

        public static Canvas GetCanvas(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Canvas>(index);
        }

        public static InputField GetInputField(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<InputField>(index);
        }

        public static Dropdown GetDropdown(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Dropdown>(index);
        }

        public static Scrollbar GetScrollbar(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Scrollbar>(index);
        }

        public static Slider GetSlider(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Slider>(index);
        }

        public static ToggleGroup GetToggleGroup(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<ToggleGroup>(index);
        }

        public static Toggle GetToggle(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Toggle>(index);
        }

        public static Button GetButton(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Button>(index);
        }

        public static RawImage GetRawImage(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<RawImage>(index);
        }

        public static Image GetImage(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Image>(index);
        }

        public static Text GetText(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Text>(index);
        }

        public static Animator GetAnimator(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Animator>(index);
        }

        public static Animation GetAnimation(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Animation>(index);
        }

        public static RectTransform GetRectTransform(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<RectTransform>(index);
        }

        public static Transform GetTransform(this ComponentCollection componentCollection, int index)
        {
            return componentCollection.GetComponent<Transform>(index);
        }
    }
}
