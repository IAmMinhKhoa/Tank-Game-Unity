using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public Transform turrentParent;
    

    protected TankMover tankMover;
    protected AimTurret aimTurret;
    protected Turret[] turrets;

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

  
  
}
