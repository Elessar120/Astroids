using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSpaceshipAttackController : MonoBehaviour
    {
        [SerializeField] private PlayerSpaceship playerSpaceship;
        private InputController inputController;
        [SerializeField] private Transform firePoint;

        private void Awake()
        {
            inputController = FindObjectOfType<InputController>();
            inputController.OnShootBullet += EnableBullet;
        }

        private void Start()
        {
        }

        private void EnableBullet()
        {
            GameObject bullet = BulletObjectPool.Instance.GetPooledObject(); 
            if (bullet != null && gameObject.activeSelf) 
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }

       
        private void OnDestroy()
        {
            inputController.OnShootBullet -= EnableBullet;

        }
    }
}