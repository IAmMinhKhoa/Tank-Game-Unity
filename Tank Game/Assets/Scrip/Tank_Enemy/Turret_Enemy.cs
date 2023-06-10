using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Enemy : MonoBehaviour
{
    public Turret turretEnemy;
    public Transform TankTuret;
    public Transform targetObject;
    public LayerMask allowedLayers;
    private Quaternion default_ps_turret;
    public bool TurnBackTurret = true;
    bool playerIntrigger = false;
   
    private void Start()
    {
        default_ps_turret = transform.rotation;       
    }
    private void Update()
    {
        LookAtTarget();
   
    }
   
    void OnTriggerStay2D(Collider2D collision)
    {
        if (allowedLayers == (allowedLayers | (1 << collision.gameObject.layer)))
        {   
            targetObject = collision.transform;
            playerIntrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (allowedLayers == (allowedLayers | (1 << collision.gameObject.layer)))
        {
            targetObject = null;
        
            playerIntrigger = false;
        }
    }
  
    void LookAtTarget()
    {
        if (playerIntrigger)
        {
            Vector2 direction = new Vector2(
            targetObject.position.x - TankTuret.position.x,
            targetObject.position.y - TankTuret.position.y);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            float rotationSpeed = 5.0f; // T?c ?? chuy?n ??i
            TankTuret.rotation = Quaternion.Lerp(TankTuret.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            if (turretEnemy.canShoot)
                turretEnemy.Shoot();

        }
        else if (playerIntrigger==false&&TurnBackTurret)
        {
          
            Quaternion QAParent = transform.parent.parent.rotation;
            TankTuret.rotation = Quaternion.RotateTowards(TankTuret.rotation, QAParent, 100 * Time.deltaTime); ;
        }
      
           
        
    }
   

}
