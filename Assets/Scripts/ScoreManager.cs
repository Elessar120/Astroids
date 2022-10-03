using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private AsteroidsObjectPool asteroidsObjectPool;
        [SerializeField] private PlayerSpaceshipHealthController playerSpaceshipHealthController;
        private float score;
        private float highScore;
        public Action<float> OnAddScore;
        public Action<float> OnUpdateHighScore;

        private void Awake()
        {
            playerSpaceshipHealthController.OnGameOver += UpdateHighScore;
            playerSpaceshipHealthController.OnGameOver += SaveHighScore;
        }

        private void Start()
        {
            GetHighScore();
            for (int i = 0; i < asteroidsObjectPool.pooledObjects.Count; i++)
            {
                asteroidsObjectPool.pooledObjects[i].OnDeath += AddScore;
            }
        }

        private void AddScore(float plusScore)
        {
            score += plusScore;
            Debug.Log(score);
            OnAddScore(score);
        }

        private void SaveHighScore()
        {
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        private void GetHighScore()
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        private void UpdateHighScore()
        {
            if (score > highScore)
            {
                highScore = score;
            }

            OnUpdateHighScore(highScore);
        }
        private void OnDestroy()
        {
            for (int i = 0; i < asteroidsObjectPool.pooledObjects.Count; i++)
            {
                asteroidsObjectPool.pooledObjects[i].OnDeath -= AddScore;
            }
            playerSpaceshipHealthController.OnGameOver -= UpdateHighScore;
            playerSpaceshipHealthController.OnGameOver -= SaveHighScore;

        }
    }
}