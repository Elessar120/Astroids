using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class AsteroidsObjectPool : MonoBehaviour
    {
        private static AsteroidsObjectPool instance;
        public static AsteroidsObjectPool Instance => instance;
        public List<AsteroidsController> pooledObjects;
        public AsteroidsController objectToPool;
        public int amountToPool;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            pooledObjects = new List<AsteroidsController>();
            AsteroidsController tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.gameObject.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

       
        public AsteroidsController GetPooledObject()
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