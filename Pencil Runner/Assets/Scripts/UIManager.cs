using System.Collections;
using TMPro;
using UnityEngine;

namespace PencilRunner
{
    public class UIManager : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private int score = 0;
        private static UIManager instance;
        public static UIManager Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            RefreshUI();
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
    }
}