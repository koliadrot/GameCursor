namespace GameDev.GameCursor
{
    using UnityEngine;

    /// <summary>
    /// Данные курсора
    /// </summary>
    [CreateAssetMenu(menuName = nameof(GameDev) + "/" + nameof(GameCursor) + "/" + nameof(CursorData), fileName = nameof(CursorData))]
    public class CursorData : ScriptableObject
    {
        /// <summary>
        /// Кол-во кадров
        /// </summary>
        public int FrameCount => textureArray.Length;

        [Header("Уникальный номер курсора:"), SerializeField]
        private string id;
        public string Id => id;

        [Header("Угол смещения курсора:"), SerializeField]
        private Vector2 offset;
        public Vector2 Offset => offset;

        [Header("Список текстур:"), SerializeField]
        private Texture2D[] textureArray;
        public Texture2D[] TextureArray => textureArray;

        [Header("Частота кадров:"), SerializeField]
        private float frameRate;
        public float FrameRate => frameRate;
    }
}
