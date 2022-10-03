using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AsteroidsController : MonoBehaviour
    {
        [SerializeField] private Asteroids Asteroids;
        public Action<float> OnDeath;

        public void SetTrajectory(Vector2 direction)
        {
           Asteroids._rigidbody2D.AddForce(direction * Asteroids.movementSpeed);
        }

        private void Start()
        {
            Asteroids._spriteRenderer.sprite = Asteroids.sprites[Random.Range(0, Asteroids.sprites.Length)];
        }

        private void Update()
        {
            if(transform.position.x > 9.5){
 
                transform.position = new Vector3(-9.5f, transform.position.y, 0);
 
            }
            else if(transform.position.x < -9.5){
                transform.position = new Vector3(9.5f, transform.position.y, 0);
            }
 
            else if(transform.position.y > 5.5){
                transform.position = new Vector3(transform.position.x, -5.5f, 0);
            }
 
            else if(transform.position.y < -5.5){
                transform.position = new Vector3(transform.position.x, 5.5f, 0);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                OnDeath?.Invoke(Asteroids.score);
                gameObject.SetActive(false);
            }
        }
        
    }
}