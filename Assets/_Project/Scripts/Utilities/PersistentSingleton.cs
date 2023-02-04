using UnityEngine;

namespace GGJ.Utilities {
    public class PersistentSingleton<T> : Singleton<T> where T : Singleton<T> {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}