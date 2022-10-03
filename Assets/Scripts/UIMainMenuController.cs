using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UIMainMenuController : MonoBehaviour
    {
        private float highScore;
        [SerializeField] private TMP_Text highScoreText;

        private void Awake()
        {
        }

        private void Start()
        {
            GetHighScore();
            SetHighScoreText();
        }

        private void GetHighScore()
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        private void SetHighScoreText()
        {
            highScoreText.text = String.Format("High Score: {0}", highScore);
        }
        public void LoadGamePlay()
        {
            SceneManager.LoadScene(1);
        }

        private void OnDestroy()
        {

        }
    }
}