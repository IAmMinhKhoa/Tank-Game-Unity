using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Move_AI : MonoBehaviour
{
    public AIPath Aipath;
    Vector2 direction;

    void Update()
    {
        faceVelocity();
      
    }
    void faceVelocity()
    {
        direction= Aipath.desiredVelocity;
        transform.up = direction;
    }
}
