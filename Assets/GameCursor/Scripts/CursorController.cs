using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCursor
{
    /// <summary>
    /// Контроллер курсора
    /// </summary>
    public class CursorController : MonoBehaviourSingletonPersistent<CursorController>
    {
        [SerializeField]
        private CursorData defaultCursor;

        private float frameTimer;
        private int currentFrame;
        private List<CursorData> cursorDatas = new List<CursorData>();
        private Coroutine coroutine;

        private void Start()
        {
            EnableCursor(defaultCursor);
            AbstractCursorCaller.onEnabledCursor += EnableCursor;
            AbstractCursorCaller.onDisabledCursor += DisableCursor;
        }

        private void OnDestroy()
        {
            StopAnimation();
            AbstractCursorCaller.onEnabledCursor -= EnableCursor;
            AbstractCursorCaller.onDisabledCursor -= DisableCursor;
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