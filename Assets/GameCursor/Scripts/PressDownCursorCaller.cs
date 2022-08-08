using UnityEngine.EventSystems;

namespace GameCursor
{
    /// <summary>
    /// Вызов смены курсора при нажатии
    /// </summary>
    public class PressDownCursorCaller : AbstractCursorCaller, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
    {
        private bool isPressed;

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchOff();
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) => SwitchOn();
        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) => SwitchOff();

        protected override void SwitchOff()
        {
            if (isPressed)
            {
                OnDisabledCursor();
                isPressed = false;
            }
        }

        protected override void SwitchOn()
        {
            OnEnabledCursor(cursorData);
            isPressed = true;
        }
    }
}