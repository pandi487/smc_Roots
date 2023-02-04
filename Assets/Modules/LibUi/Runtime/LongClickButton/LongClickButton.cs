using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.LibUi.Runtime.LongClickButton
{
    [AddComponentMenu("UI/LongClickButton")]
    public class LongClickButton : Button
    {
        [Serializable] public class ButtonLongClickedEvent : UnityEvent
        {
        }

        [Header("Long click settings")]
        [SerializeField] private float longClickTime = 1;
        [SerializeField] private float animationStartThreshold;
        [SerializeField] private bool autoClickOnTimeEnd;
        [SerializeField] private RectTransform maskTransform;
        [SerializeField] private ButtonLongClickedEvent onLongClick = new ButtonLongClickedEvent();

        private float _startTime;
        private bool _animating;

        #region Unity Functions

        protected override void Start()
        {
            base.Start();
            StopTimer();
        }

        private void Update()
        {
            if (_animating)
            {
                var elapsed = Time.timeSinceLevelLoad - _startTime;
                if (elapsed >= animationStartThreshold)
                    UpdateGraphic((elapsed - animationStartThreshold) / (longClickTime - animationStartThreshold));
                if (autoClickOnTimeEnd && elapsed >= longClickTime)
                    EndClick();
            }
        }

        #endregion

        #region OnPointer Callbacks

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            StartTimer();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            EndClick();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            StopTimer();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            //Skip parent class implementation
        }

        #endregion

        #region Clicks Callbacks

        private void Press()
        {
            if (!IsActive() || !IsInteractable())
                return;
            onClick.Invoke();
        }

        private void LongPress()
        {
            if (!IsActive() || !IsInteractable())
                return;
            onLongClick.Invoke();
        }

        #endregion

        #region Timer management

        private void StartTimer()
        {
            _startTime = Time.timeSinceLevelLoad;
            _animating = true;
            UpdateGraphic(0);
        }

        private void UpdateGraphic(float percentage)
        {
            percentage = Mathf.Clamp(percentage, 0, 1);
            var maskWidth = targetGraphic.rectTransform.sizeDelta.x * percentage;
            maskTransform.sizeDelta = new Vector2(maskWidth, maskTransform.sizeDelta.y);
        }

        private void EndClick()
        {
            if (_startTime == 0)
                return;
            var currentTime = Time.timeSinceLevelLoad;
            if (currentTime - _startTime <= longClickTime)
                Press();
            else
                LongPress();
            StopTimer();
        }

        private void StopTimer()
        {
            _startTime = 0;
            _animating = false;
            UpdateGraphic(0);
        }

        #endregion
    }
}