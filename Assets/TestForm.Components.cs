//------------------------------------------------------------
// 此文件由 ComponentCollection 自动生成，请勿直接修改。
// 生成时间：2022-08-02 11:35:04.11
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameExtension;

namespace Game
{
    public partial class TestForm 
    {
        private VerticalLayoutGroup m_GameVLGroup;
        private Text m_GameText;
        private Image m_GameImage;
        private RawImage m_GameRawImage;
        private Button m_GameButton;
        private Toggle m_GameToggle;
        private Slider m_GameSlider;
        private Scrollbar m_GameScrollbar;
        private Dropdown m_GameDropdown;
        private InputField m_GameInputField;
        private ScrollRect m_GameScrollView;
        private HorizontalLayoutGroup m_GameHLGroup;
        private Animation m_GameAnim;
        private Mask m_GameMask;
        private RectMask2D m_GameRectMask;
        private GridLayoutGroup m_GameGLGroup;
        private CanvasGroup m_GameCGroup;
        private ToggleGroup m_GameTGroup;

        /// <summary>
        /// 初始化组件。
        /// </summary>
        public void InitComponents(GameObject target)
        {
            var collection = target.GetComponent<ComponentCollection>();
            m_GameVLGroup = collection.GetComponent<VerticalLayoutGroup>(0);
            m_GameText = collection.GetComponent<Text>(1);
            m_GameImage = collection.GetComponent<Image>(2);
            m_GameRawImage = collection.GetComponent<RawImage>(3);
            m_GameButton = collection.GetComponent<Button>(4);
            m_GameToggle = collection.GetComponent<Toggle>(5);
            m_GameSlider = collection.GetComponent<Slider>(6);
            m_GameScrollbar = collection.GetComponent<Scrollbar>(7);
            m_GameDropdown = collection.GetComponent<Dropdown>(8);
            m_GameInputField = collection.GetComponent<InputField>(9);
            m_GameScrollView = collection.GetComponent<ScrollRect>(10);
            m_GameHLGroup = collection.GetComponent<HorizontalLayoutGroup>(11);
            m_GameAnim = collection.GetComponent<Animation>(12);
            m_GameMask = collection.GetComponent<Mask>(13);
            m_GameRectMask = collection.GetComponent<RectMask2D>(14);
            m_GameGLGroup = collection.GetComponent<GridLayoutGroup>(15);
            m_GameCGroup = collection.GetComponent<CanvasGroup>(16);
            m_GameTGroup = collection.GetComponent<ToggleGroup>(17);
        }
    }
}
