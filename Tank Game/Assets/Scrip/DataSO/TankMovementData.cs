using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementData : ScriptableObject 
{
    public float MaxSpeed = 300;
    public float speedRotation = 20;

    public float acceleration = 70;
    public float deaccelereration = 50;
}
