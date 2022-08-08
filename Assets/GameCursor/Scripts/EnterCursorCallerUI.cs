using UnityEngine.EventSystems;

namespace GameCursor
{
    /// <summary>
    /// Вызов смены курсора при входе на UI элемент
    /// </summary>
    public class EnterCursorCallerUI : AbstractCursorCaller, IPointerEnterHandler, IPointerExitHandler
    {
        protected override void SwitchOff() => OnDisabledCursor();
        protected override void SwitchOn() => OnEnabledCursor(cursorData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => SwitchOn();
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => SwitchOff();
    }
}
