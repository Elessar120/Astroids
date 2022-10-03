using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 1f;
        public float maxLifetime = 10f;
        public float screenRightEdge;
        public float screenLeftEdge;
        public float screenUpperEdge;
        public float screenBottomEdge;
        public float damage = 1f;
    }
}