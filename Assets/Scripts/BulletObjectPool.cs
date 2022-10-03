using UnityEngine;
using System.Collections.Generic;
namespace DefaultNamespace
{
    public class BulletObjectPool : MonoBehaviour
    {
        private static BulletObjectPool instance;
        public static BulletObjectPool Instance => instance;
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.gameObject.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
        public GameObject GetPooledObject()
        {
            for(int i = 0; i < amountToPool; i++)
            {
                if(!pooledObjects[i].gameObject.activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
    }
