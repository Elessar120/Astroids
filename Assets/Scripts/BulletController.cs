using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] private Rigidbody2D rigidbody2D;
        private float lifeTime;
        private void OnEnable()
        {
            lifeTime = bullet.maxLifetime;
            Move();
        }

        private void Update()
        {
           
            if(transform.position.x > bullet.screenRightEdge)
            {
                transform.position = new Vector3(-1 * bullet.screenRightEdge, transform.position.y, 0);
            }
            else if(transform.position.x < bullet.screenLeftEdge)
            {
                transform.position = new Vector3(-1 * bullet.screenLeftEdge, transform.position.y, 0);
            }

            else if(transform.position.y > bullet.screenUpperEdge)
            {
                transform.position = new Vector3(transform.position.x, -1 * bullet.screenUpperEdge, 0);
            }

            else if(transform.position.y < bullet.screenBottomEdge)
            {
                transform.position = new Vector3(transform.position.x, -1 * bullet.screenBottomEdge, 0);
            }
        }

        private void Move()
        {
            if (rigidbody2D)
            {
                rigidbody2D.AddForce(transform.up * bullet.speed);

            }
        }

       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Asteroid"))
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}