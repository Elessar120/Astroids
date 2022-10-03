using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSpaceshipHealthController : MonoBehaviour
    {
        private int newHealth;  
        [SerializeField] private PlayerSpaceshipDeathController _deathController;
        [SerializeField] private PlayerSpaceship playerSpaceship;
        public Action OnLoseOneLife;
        public Action OnGameOver;
        private void Awake()
        {
            _deathController.OnLoseHealth += TakeDamage;
        }

        private void TakeDamage(int currentHealth)
        {
            newHealth = currentHealth - 1;
            if (gameObject.CompareTag("Player"))
            {
                OnLoseOneLife();
                playerSpaceship.health = newHealth;
            }
            if (newHealth <= 0 )
            {
                Destroy(gameObject);
            }
        }

        public float GetHealth()
        {
            return playerSpaceship.health;  
        }
        private void OnDestroy()
        {
            _deathController.OnLoseHealth -= TakeDamage;
            OnGameOver?.Invoke();
        }
    }
}