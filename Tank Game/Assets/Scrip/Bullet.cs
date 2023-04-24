using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet = 10;
    public int damage = 5;
    public float maxDistance = 10;
    public GameObject explosionPrefab;

    protected Vector2 startPosition;
    protected float conquaredDistance = 0;
    protected Rigidbody2D rb2d;
    protected Health healt;
    public LayerMask[] allowedLayers;
  

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
   

    private void Update()
    {
        Init();
        conquaredDistance =Vector2.Distance(transform.position,startPosition);
        if (conquaredDistance >= maxDistance)
            DisableObject();
    }

    private void DisableObject()
    {
        
        /*GameObject Tankturret = GameObject.Find("TankTurret");
        
        ObjectPool returnObjectPool= Tankturret.GetComponent<ObjectPool>();
        returnObjectPool.ReturnObject(this.gameObject);*/
       gameObject.SetActive(false);
    }

    public void Init()
    {
        
        startPosition = transform.position;
        rb2d.velocity = transform.up * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        for (int i = 0; i < allowedLayers.Length; i++)
        {
            // Ki?m tra xem va ch?m có x?y ra v?i các layer ???c cho phép
            if (((1 << collision.gameObject.layer) & allowedLayers[i].value) != 0)
            {
                // X? lý va ch?m ? ?ây
                DisableObject();
                String name_layer = LayerMask.LayerToName(collision.gameObject.layer);
                if (name_layer == "enemies"|| name_layer == "player")
                {
                    healt = collision.gameObject.GetComponent<Health>();
                    

                    healt.TakeDamage(damage);
                }
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);

            }

        }
    }





}
