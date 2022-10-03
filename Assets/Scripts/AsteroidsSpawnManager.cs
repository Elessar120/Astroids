using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AsteroidsSpawnManager : MonoBehaviour
    {
        public float spawnDistance = 12f;
        public float spawnRate = 1f;
        public int amountPerSpawn = 1;
        [Range(0f, 45f)]
        public float trajectoryVariance = 15f;

        private void Awake()
        {
            
        }

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }

       
        public void Spawn()
        {
            if (gameObject.activeSelf)
            {
                for (int i = 0; i < amountPerSpawn; i++)
                {
                    Vector2 spawnDirection = Random.insideUnitCircle.normalized;
                    Vector3 spawnPoint = spawnDirection * spawnDistance;

                    spawnPoint += transform.position;

                    float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                    Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                    AsteroidsController asteroids = AsteroidsObjectPool.Instance.GetPooledObject(); 
                    if (asteroids != null) 
                    {
                        asteroids.transform.position = spawnPoint;
                        asteroids.transform.rotation = rotation;
                        asteroids.gameObject.SetActive(true);
                        Vector2 trajectory = rotation * -spawnDirection;
                        asteroids.GetComponent<AsteroidsController>().SetTrajectory(trajectory);

                    }              

                }
            }
          
        }
    }
}