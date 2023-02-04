using UnityEngine;

namespace Platformer.Utilities {
    public class Singleton<T> : MonoBehaviour where T : Singleton<T> {
        protected static T _instance;

        public static T instance {
            get {
                if (_instance != null) return _instance;

                _instance = GameObject.FindObjectOfType<T> ();

                if(_instance != null) return _instance;

                GameObject singletonObj = new GameObject();
                singletonObj.name = typeof(T).ToString();
                _instance = singletonObj.AddComponent<T>();

                return _instance;
            }
        }

        protected virtual void Awake() {
            if (_instance != null) {
                Destroy(gameObject);
                return;
            }

            _instance = (T)this;
        }

        protected virtual void OnDestroy() {
            if (_instance == this) _instance = null;
        }
    }
}