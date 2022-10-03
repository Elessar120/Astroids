using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LifeTimeController : MonoBehaviour
    {
        private float lifeTime;
        [SerializeField] private Bullet bullet;
        [SerializeField] private Asteroids asteroids;

        public enum TimingUnits
        {
            Bullet,
            Asteroids
        }

        public TimingUnits name;

        private void OnEnable()
        {
            SetTimer();
        }

        private void SetTimer()
        {
            switch (name)
            {
                case TimingUnits.Bullet:
                    lifeTime = bullet.maxLifetime;
                    break;
                case TimingUnits.Asteroids:
                    lifeTime = asteroids.maxLifetime;
                    break;
            }
        }

        private void Update()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}