using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
   

    public void aimForward(Vector2 pointerPosition)
    {
        Vector2 direction = new Vector2(
           pointerPosition.x - transform.position.x,
           pointerPosition.y - transform.position.y);
        
        transform.up = direction;
      
    }
}
