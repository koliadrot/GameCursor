using System;
using UnityEngine;

namespace GameCursor
{
    /// <summary>
    /// Базовая реализация вызова смены курсора
    /// </summary>
    public abstract class AbstractCursorCaller : MonoBehaviour
    {
        public static event Action<CursorData> onEnabledCursor = delegate { };
        public static event Action onDisabledCursor = delegate { };

        [SerializeField]
        protected CursorData cursorData;

        /// <summary>
        /// Активация курсора
        /// </summary>
        protected abstract void SwitchOn();
        /// <summary>
        /// Деактивация курсора
        /// </summary>
        protected abstract void SwitchOff();

        protected void OnEnabledCursor(CursorData abstractCursorData) => onEnabledCursor(abstractCursorData);
        protected void OnDisabledCursor() => onDisabledCursor();

    }
}