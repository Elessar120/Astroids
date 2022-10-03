using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class PlayerSpaceshipMoveController : MonoBehaviour
    {
        [SerializeField] private PlayerSpaceship playerSpaceship;
        [FormerlySerializedAs("rigidbody2D")] [SerializeField] private Rigidbody2D _rigidbody2D;

        public void LinearMove()
        {
            if (_rigidbody2D)
            {
                _rigidbody2D.AddForce(transform.up * playerSpaceship.thrustSpeed);

            }

        }

        public void RotationalMove(float turnDirection)
        {
            if (_rigidbody2D)
            {
                _rigidbody2D.AddTorque(playerSpaceship.rotationSpeed * turnDirection);

            }

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
    }
}