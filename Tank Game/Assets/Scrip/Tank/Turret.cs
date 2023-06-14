using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Transform> turetBarels;

    public TurretData turretData;

    public bool canShoot = true;

    public ObjectPool bulletPool;
    public int max_bullet=10;


    public GameObject prefab;
    private void Start()
    {
        bulletPool.Innit(prefab, max_bullet);
    }
    private void Update()
    {
   
        if (canShoot==false )
        {
            turretData.currentDelay -= Time.deltaTime;
            if (turretData.currentDelay <= 0)
            {
                canShoot = true;
            }
        }
      
    }
    public void Shoot()
    {
        if (canShoot)
        {
            
            canShoot = false;
            turretData.currentDelay = turretData.reloaDelay;
            Sound_Manager.instance.PlaySound(SoundType.Shoot);
            foreach (var barrel in turetBarels)
            {
               
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;

            }
            
        }
    }

    public void ShootAuto()
    {
     
            foreach (var barrel in turetBarels)
            {
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
            }

    }
   
}
