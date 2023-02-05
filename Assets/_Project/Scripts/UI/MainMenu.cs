using UnityEngine;
using GGJ.Managers;

namespace GGJ.UI {
    public class MainMenu : MonoBehaviour {
        public void OnPlayClicked() {
            SceneTransitionManager.instance.LoadLevel("GameScene");
        }

        public void OnCreditsClicked() {
            SceneTransitionManager.instance.LoadLevel("Credits");
        }

        // public void OnVolumeClicked() {
        //     volumeOn = !volumeOn;
        //     SetVolumeSprite();
        // }

        // private void SetVolumeSprite() {
        //     m_volumeImage.sprite = volumeOn ? m_volumeOn : m_volumeOff;
        // }

        public void OnQuitClicked() {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }
}
