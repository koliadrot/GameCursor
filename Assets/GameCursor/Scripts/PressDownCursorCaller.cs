namespace GameCursor
{
    /// <summary>
    /// Активация курора при нажатии на объект
    /// </summary>
    public class PressDownCursorCaller : AbstractCursorCaller
    {
        private bool isPressed;

        private void OnMouseDown() => SwitchOn();
        private void OnMouseExit() => SwitchOff();
        private void OnMouseUp() => SwitchOff();
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