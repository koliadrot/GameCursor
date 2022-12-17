namespace GameDev.GameCursor
{
    using UnityEngine;

    /// <summary>
    /// Синглтон
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
