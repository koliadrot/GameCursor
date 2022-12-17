namespace GameDev.GameDev
{
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Editor скрипт для определения текущей версии плагина.
    /// </summary>
    public class GetVersionPluginEditor
    {
        private const string CURRENT_VERSION = "1.0.1";

        [MenuItem("GameDev/GameDev/Version - " + CURRENT_VERSION)]
        public static void GetVersionInfo() => Debug.Log("GameDev версия - " + CURRENT_VERSION);
    }
}
