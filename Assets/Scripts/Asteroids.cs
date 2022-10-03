using UnityEngine;

namespace DefaultNamespace
{
    public class Asteroids : MonoBehaviour
    {
        public Rigidbody2D _rigidbody2D;
        public SpriteRenderer _spriteRenderer;
        public Sprite[] sprites;
        public float movementSpeed = 50f;
        public float maxLifetime = 30f;
        public float score = 5;
    }
}