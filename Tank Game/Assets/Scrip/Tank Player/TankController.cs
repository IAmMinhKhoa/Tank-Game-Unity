using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public Transform turrentParent;
    

    protected TankMover tankMover;
    protected AimTurret aimTurret;
    protected Turret[] turrets;
    public float timeRemainingItemLightning;
    public bool isItemLightning = false;

    private void Awake()
    {
        if (tankMover == null)
        {
            tankMover =GetComponentInChildren<TankMover>();
        }
        if (aimTurret == null)
        {
            aimTurret = GetComponentInChildren<AimTurret>();
        }
        if(turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }
   
    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }
    
    public void HandleMoveBody(Vector2 movementVector)
    {
        
        tankMover.Move(movementVector);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.aimForward(pointerPosition);

    }
  

    public void EatItemLightning(float time)
    {
        StartCoroutine(ItemLightning(time));
    }
    protected IEnumerator ItemLightning(float time)
    {
        if (!isItemLightning)
        {
            isItemLightning = true;
            
            //get object and boost MAXSPEED AND ACCELERATION OF TANK PLAYER
            GameObject firstTankBase = transform.GetChild(0).gameObject;
            float temp_speed = firstTankBase.GetComponent<TankMover>().MaxSpeed;
            float temp_acceleration = firstTankBase.GetComponent<TankMover>().acceleration;

            
            firstTankBase.GetComponent<TankMover>().MaxSpeed = temp_speed * 3;
            firstTankBase.GetComponent<TankMover>().acceleration = temp_acceleration * 3;

            float remainingTime = time;
            while (remainingTime > 0)
            {
                timeRemainingItemLightning = remainingTime;
                remainingTime--;
                yield return new WaitForSeconds(1);
                
                
            }

            
           
            
            firstTankBase.GetComponent<TankMover>().MaxSpeed = temp_speed;
            firstTankBase.GetComponent<TankMover>().acceleration = temp_acceleration;
            isItemLightning = false;
        }  
      
    }
  

}
