using UnityEngine;
using TMPro;

using GGJ.Managers;

namespace GGJ.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void OnEnable() {
            Time.timeScale = 0;
            scoreText.text = (100 - scoreManager.enemiesLeft).ToString() + " / 100";
        }

        public void ReloadLevel() {
            SceneTransitionManager.instance.ReloadLevel();
        }

        public void LoadMenu() {
            SceneTransitionManager.instance.LoadLevel("Menu");
        }
    }
}