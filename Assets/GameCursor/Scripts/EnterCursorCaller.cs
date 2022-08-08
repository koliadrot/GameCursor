using UnityEngine.EventSystems;

namespace GameCursor
{
    /// <summary>
    /// Вызов смены курсора при входе
    /// </summary>
    public class EnterCursorCaller : AbstractCursorCaller, IPointerEnterHandler, IPointerExitHandler
    {
        protected override void SwitchOff() => OnDisabledCursor();
        protected override void SwitchOn() => OnEnabledCursor(cursorData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => SwitchOn();
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchOff();
    }
}
