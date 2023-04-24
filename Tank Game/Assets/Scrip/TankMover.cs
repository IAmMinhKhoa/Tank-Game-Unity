using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Vector2 movementVector;

    public TankMovementData movementData;

    public float currentSpeed = 0;
    public float currentForewardDirection = 1;
    
    private void Awake()
    {
          rb2d = GetComponentInParent<Rigidbody2D>();
    }
    public void Move(Vector2 movementvector)
    {
        this.movementVector = movementvector;
        CalculateSpeed(movementvector);

        if (movementVector.y > 0)
        {
            currentForewardDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            currentForewardDirection = -1;
        }
    }

    private void CalculateSpeed(Vector2 movementvector)
    {
        if (Mathf.Abs(movementvector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed=0;
            currentSpeed-= movementData.deaccelereration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.MaxSpeed);
    }

    private void FixedUpdate()
    {
        Time.fixedDeltaTime = 0.01f;
        rb2d.velocity = (Vector2)transform.up * currentSpeed *currentForewardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.speedRotation * Time.fixedDeltaTime));

    }




}
