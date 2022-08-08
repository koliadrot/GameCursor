namespace GameCursor
{
    /// <summary>
    /// Изменяет курсор при наведении на объект
    /// </summary>
    public class EnterCursorCaller : AbstractCursorCaller
    {
        private void OnMouseEnter() => SwitchOn();
        private void OnMouseExit() => SwitchOff();

        protected override void SwitchOff() => OnDisabledCursor();

        protected override void SwitchOn() => OnEnabledCursor(cursorData);
    }
}