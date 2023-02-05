using UnityEngine;
using UnityEngine.SceneManagement;

using GGJ.Utilities;
using System.Collections;

namespace GGJ.Managers
{
    public class SceneTransitionManager : PersistentSingleton<SceneTransitionManager> {
        [SerializeField] private Animator m_animator;

        private int fadeParamID;

        protected override void Awake() {
            base.Awake();

            fadeParamID = Animator.StringToHash("Fade");
            SceneManager.activeSceneChanged += MoveOut;
        }

        public void LoadLevel(string nextLevel) {
            StartCoroutine(MoveIn(nextLevel));
        }

        public void ReloadLevel() {
            StartCoroutine(MoveIn(SceneManager.GetActiveScene().name));
        }

        private IEnumerator MoveIn(string nextLevel) {
            m_animator.SetBool(fadeParamID, false);
            yield return new WaitForSeconds(0.6f);
            SceneManager.LoadScene(nextLevel);
        }
        
        private void MoveOut(Scene prev, Scene next) {
            m_animator.SetBool(fadeParamID, true);
        }

        protected override void OnDestroy() {
            base.OnDestroy();
            SceneManager.activeSceneChanged -= MoveOut;
        }
    }    
}