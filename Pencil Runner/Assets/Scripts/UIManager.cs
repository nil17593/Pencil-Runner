using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PencilRunner
{
    public class UIManager : MonoBehaviour
    {
        #region Serialized Fields
        [Header("In Game UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private string menuScene;
        [SerializeField] private GameObject levelWinPanel;
        [SerializeField] private Button nextLevelBtn;
        [SerializeField] private Button levelWinMenuBtn;

        [Header("GameOver Panel")]
        [SerializeField] private GameObject gameoverPanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuBtn;
        [SerializeField] private string currentScene;
        #endregion

        private int score = 0;
        private static UIManager instance;
        public static UIManager Instance { get { return instance; } }
        public static bool GameIsPaused = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void Start()
        {
            RefreshUI();
            pauseButton.onClick.AddListener(Pause);
            resumeButton.onClick.AddListener(Resume);
            quitButton.onClick.AddListener(QuitGame);
            menuButton.onClick.AddListener(LoadMenu);
            restartButton.onClick.AddListener(RestartGame);
            menuBtn.onClick.AddListener(LoadMenu);
            levelWinMenuBtn.onClick.AddListener(LoadMenu);
        }

        public void IncreaseScore(int increament)
        {
            score += increament;
            RefreshUI();
        }

        private void RefreshUI()
        {
            scoreText.text = "0" + score;
        }

        //private void PauseGame()
        //{
        //    if (!GameIsPaused)
        //    {
        //        Pause();
        //    }
        //}

        private void Pause()
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        private void Resume()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void LoadMenu()
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            GameIsPaused = false;
            SceneManager.LoadScene(menuScene);
        }

        private void QuitGame()
        {
            GameIsPaused = false;
            Debug.Log("Quitting");
            Application.Quit();
        }

        public void LoadGameoverPanel()
        {
            gameoverPanel.SetActive(true);
        }

        public void LoadLevelWinPanel()
        {
            levelWinPanel.SetActive(true);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}