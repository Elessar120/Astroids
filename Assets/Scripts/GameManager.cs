using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerSpaceship playerSpaceship;
        [SerializeField] private GameObject asteroidsSpawner;
        [SerializeField] private PlayerSpaceshipDeathController deathController;
        private float restartDelay;
        private void Awake()
        {
            deathController.OnResetGame += DisableAllAsteroids;
            deathController.OnResetGame += DisableAllBullets;
            deathController.OnResetGame += CallReenableGameStuffCoroutine;
            deathController.OnResetGame += ResetPlayerPosition;

        }

        private void Start()
        {
            restartDelay = playerSpaceship.respawnDelay;
        }

        private void ResetPlayerPosition()
        {
            playerSpaceship.transform.position = Vector3.zero;
            playerSpaceship.transform.rotation = quaternion.identity;
        }

        private void DisableAllAsteroids()
        {
            if (asteroidsSpawner)
            {
                asteroidsSpawner.SetActive(false);
            }
            for (int i = 0; i < AsteroidsObjectPool.Instance.pooledObjects.Count; i++)
            {
                if (AsteroidsObjectPool.Instance.pooledObjects[i] != null)
                {
                    AsteroidsObjectPool.Instance.pooledObjects[i].gameObject.SetActive(false);
                }
            }
        }

        private void DisableAllBullets()
        {
            for (int i = 0; i < BulletObjectPool.Instance.pooledObjects.Count; i++)
            {
                if (BulletObjectPool.Instance.pooledObjects[i] != null)
                {
                    BulletObjectPool.Instance.pooledObjects[i].gameObject.SetActive(false);
                }
            }
        }

        private void CallReenableGameStuffCoroutine()
        {
            StartCoroutine(nameof(ReenableGameStuff));
        }
        private IEnumerator ReenableGameStuff()
        {
            yield return new WaitForSeconds(restartDelay);
            if (playerSpaceship)
            {
                playerSpaceship.gameObject.SetActive(true);
                asteroidsSpawner.SetActive(true);

            }

        }
        private void OnDestroy()
        {
            deathController.OnResetGame -= ResetPlayerPosition;
            deathController.OnResetGame -= DisableAllAsteroids;
            deathController.OnResetGame -= DisableAllBullets;
            deathController.OnResetGame -= CallReenableGameStuffCoroutine;

        }
    }
}