using UnityEngine;

namespace GameCursor
{
    /// <summary>
    /// Дата курсора
    /// </summary>

    [CreateAssetMenu(fileName = nameof(CursorData), menuName = "GameCursor/" + nameof(CursorData))]
    public class CursorData : ScriptableObject
    {
        /// <summary>
        /// Уникальный номер id
        /// </summary>
        public string Id => id;
        /// <summary>
        /// Угол смещения курсора
        /// </summary>
        public Vector2 Offset => offset;
        /// <summary>
        /// Список текстур
        /// </summary>
        public Texture2D[] TextureArray => textureArray;
        /// <summary>
        /// Частота кадров
        /// </summary>
        public float FrameRate => frameRate;

        /// <summary>
        /// Кол-во кадров
        /// </summary>
        public int FrameCount => textureArray.Length;

        [Header("Уникальный номер курсора:"), SerializeField]
        private string id;
        [Header("Угол смещения курсора:"), SerializeField]
        private Vector2 offset;
        [Header("Список текстур:"), SerializeField]
        private Texture2D[] textureArray;
        [Header("Частота кадров:"), SerializeField]
        private float frameRate;
    }
}
