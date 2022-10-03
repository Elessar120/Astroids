using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerSpaceshipMoveController moveController;
    [SerializeField] private PlayerSpaceshipAttackController attackController;
    public Action OnShootBullet;
    public bool Thrusting { get; private set; }

    public float TurnDirection { get; private set; }
        

    private void Update()
    {
        Thrusting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnDirection = 1f;
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnDirection = -1f;
        } 
        else 
        {
            TurnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            OnShootBullet?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (Thrusting)
        {
            moveController.LinearMove();
        }

        if (TurnDirection != 0f)
        {
            moveController.RotationalMove(TurnDirection);
        }
    }
}
