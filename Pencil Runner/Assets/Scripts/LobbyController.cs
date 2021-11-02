using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PencilRunner
{
    public class LobbyController : MonoBehaviour
    {
        #region
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private string gameScene;
        #endregion


        private void Start()
        {
            playButton.onClick.AddListener(LoadGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void LoadGame()
        {
            UIManager.GameIsPaused = false;
            SceneManager.LoadScene(gameScene);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}