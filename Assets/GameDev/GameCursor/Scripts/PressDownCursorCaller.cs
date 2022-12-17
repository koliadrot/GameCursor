namespace GameDev.GameCursor
{
    using UnityEngine.EventSystems;

    /// <summary>
    /// Вызов смены курсора при нажатии
    /// </summary>
    public class PressDownCursorCaller : AbstractCursorCaller, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
    {
        private bool isPressed = default;

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchOff();
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) => SwitchOn();
        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) => SwitchOff();

        protected override void SwitchOff()
        {
            if (isPressed)
            {
                OnDisabledCursorEvent();
                isPressed = false;
            }
        }

        protected override void SwitchOn()
        {
            OnEnabledCursorEvent(cursorData);
            isPressed = true;
        }
    }
}