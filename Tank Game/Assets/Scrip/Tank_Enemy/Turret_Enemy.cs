using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Turret_Enemy : MonoBehaviour
{
    public Turret turretEnemy;
    public Transform targetObject;
    public LayerMask allowedLayers;
    private Quaternion default_ps_turret;
    bool playerIntrigger = false;
    bool canShoot = true;
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
        targetObject = null;
        playerIntrigger = false;
    }
  
    void LookAtTarget()
    {
        if (playerIntrigger)
        {
            Vector2 direction = new Vector2(
            targetObject.position.x - transform.position.x,
            targetObject.position.y - transform.position.y);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            float rotationSpeed = 5.0f; // T?c ?? chuy?n ??i
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            if (turretEnemy.canShoot)
                turretEnemy.Shoot();

        }
        else if (playerIntrigger==false)
        {
            
            Quaternion QAParent = transform.parent.rotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, QAParent, 100 * Time.deltaTime); ;
        }
      
            
        
    }
   

}
