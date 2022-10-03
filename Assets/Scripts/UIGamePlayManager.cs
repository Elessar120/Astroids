using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class UIGamePlayManager : MonoBehaviour
    {
        [SerializeField] private PlayerSpaceshipHealthController playerSpaceshipHealthController;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TMP_Text inGameScoreText;
        [SerializeField] private TMP_Text gameOverScoreText;
        [SerializeField] private TMP_Text gameOverHighScoreText;
        [SerializeField] private TMP_Text livesText;
        [SerializeField] private GameObject gameOverPanel;
        public GameObject[] healthIcons;

        private void Awake()
        {
            scoreManager.OnAddScore += UpdateScoreText;
            scoreManager.OnUpdateHighScore += UpdateHighScoreText;
            playerSpaceshipHealthController.OnLoseOneLife += DisableLifeIcon;
            playerSpaceshipHealthController.OnGameOver += DisableInGameInfo;
            playerSpaceshipHealthController.OnGameOver += ShowGameOverUI;

        }

        private void Start()
        {
            float hearts = playerSpaceshipHealthController.GetHealth();
            for (int i = 0; i < hearts; i++)
            {
               healthIcons[i].SetActive(true);
            }
        }

        private void DisableLifeIcon()
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                if (healthIcons[i].activeSelf)
                {
                    healthIcons[i].SetActive(false);
                    break;
                }
            }
        }

        private void DisableInGameInfo()
        {
            livesText.gameObject.SetActive(false);
            inGameScoreText.gameObject.SetActive(false);
        }
        private void ShowGameOverUI()
        {
            gameOverPanel.SetActive(true);
        }

        private void UpdateScoreText(float score)
        {
            inGameScoreText.text = String.Format("Score: {0}", score);
            gameOverScoreText.text = String.Format("Score: {0}", score);
        }
        private void UpdateHighScoreText(float highScore)
        {
            gameOverHighScoreText.text = String.Format("High Score: {0}", highScore);
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(0);
        }
        private void OnDestroy()
        {
            scoreManager.OnAddScore -= UpdateScoreText;
            scoreManager.OnUpdateHighScore -= UpdateHighScoreText;
            playerSpaceshipHealthController.OnLoseOneLife -= DisableLifeIcon;
            playerSpaceshipHealthController.OnGameOver -= DisableInGameInfo;
            playerSpaceshipHealthController.OnGameOver -= ShowGameOverUI;

        }
    }
}