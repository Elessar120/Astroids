using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSpaceshipDeathController : MonoBehaviour
    {
        [SerializeField] private PlayerSpaceship PlayerSpaceship;
        public Action<int> OnLoseHealth;
        public Action OnResetGame;
       // public Action OnTakeDamage;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet") || other.CompareTag("Asteroid"))
            {
                OnLoseHealth(PlayerSpaceship.health);
                gameObject.SetActive(false);
                //OnTakeDamage();
                //Destroy(gameObject);
            }
        }

        private void OnDisable()
        {
            if (PlayerSpaceship.gameObject)
            {
                OnResetGame?.Invoke();

            }
        }
    }
}