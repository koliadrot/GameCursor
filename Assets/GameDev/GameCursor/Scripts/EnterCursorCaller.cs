namespace GameDev.GameCursor
{
    using UnityEngine.EventSystems;

    /// <summary>
    /// Вызов смены курсора при входе
    /// </summary>
    public class EnterCursorCaller : AbstractCursorCaller, IPointerEnterHandler, IPointerExitHandler
    {
        protected override void SwitchOff() => OnDisabledCursorEvent();
        protected override void SwitchOn() => OnEnabledCursorEvent(cursorData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => SwitchOn();
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchOff();
    }
}
