namespace GameDev.GameCursor
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Базовая реализация вызова смены курсора
    /// </summary>
    public abstract class AbstractCursorCaller : MonoBehaviour
    {
        public static event Action<CursorData> OnEnabledCursor = delegate { };
        public static event Action OnDisabledCursor = delegate { };

        [Header("Данные курсора"), SerializeField]
        protected CursorData cursorData = default;

        /// <summary>
        /// Активация курсора
        /// </summary>
        protected abstract void SwitchOn();

        /// <summary>
        /// Деактивация курсора
        /// </summary>
        protected abstract void SwitchOff();

        protected void OnEnabledCursorEvent(CursorData abstractCursorData) => OnEnabledCursor(abstractCursorData);
        protected void OnDisabledCursorEvent() => OnDisabledCursor();

    }
}