namespace GameDev.GameCursor
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// Контроллер курсора
    /// </summary>
    public class CursorController : MonoBehaviourSingletonPersistent<CursorController>
    {
        [Header("Данные курсора по-умолчанию:"), SerializeField]
        private CursorData defaultCursor = default;
        [Header("Камера для обработки 3д касаний:"), SerializeField]
        private Camera mainCamera = default;

        private float frameTimer = default;
        private int currentFrame = default;
        private List<CursorData> cursorDatas = new List<CursorData>();
        private Coroutine coroutine = default;

        private void Start()
        {
            EnableCursor(defaultCursor);
            AbstractCursorCaller.OnEnabledCursor += EnableCursor;
            AbstractCursorCaller.OnDisabledCursor += DisableCursor;
        }

        private void OnDestroy()
        {
            StopAnimation();
            AbstractCursorCaller.OnEnabledCursor -= EnableCursor;
            AbstractCursorCaller.OnDisabledCursor -= DisableCursor;
        }

        private void EnableCursor(CursorData cursorData)
        {
            StopAnimation();
            if (cursorData.FrameCount == 0)
            {
#if UNITY_EDITOR
                Debug.LogError($"Список доступных текстур пуст для данного курсора {cursorData.Id}");
#endif
                return;
            }
            coroutine = StartCoroutine(AnimateCursor(cursorData));
            cursorDatas.Add(cursorData);
        }
        private void DisableCursor()
        {
            cursorDatas.RemoveAt(cursorDatas.Count - 1);
            EnableCursor(cursorDatas.Last());
            cursorDatas.RemoveAt(cursorDatas.Count - 1);
        }
        private void StopAnimation()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        private IEnumerator AnimateCursor(CursorData cursorData)
        {
            Cursor.SetCursor(cursorData.TextureArray[0], cursorData.Offset, CursorMode.Auto);
            while (enabled && cursorData.FrameCount > 1)
            {
                frameTimer -= Time.deltaTime;
                if (frameTimer <= 0f)
                {
                    frameTimer += cursorData.FrameRate;
                    currentFrame = (currentFrame + 1) % cursorData.FrameCount;
                    Cursor.SetCursor(cursorData.TextureArray[currentFrame], cursorData.Offset, CursorMode.Auto);
                }
                yield return null;
            }
            coroutine = null;
        }
    }
}