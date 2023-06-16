using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet = 10;
    public int damage = 5;
    public float maxDistance = 10;

    protected Vector2 startPosition;
    protected float conquaredDistance = 0;
    protected Rigidbody2D rb2d;
    protected Health healt;
    public LayerMask[] allowedLayers;

    //public   ObjectPool pool;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
       // pool.Innit(explosionPrefab, 10);
        startPosition = transform.position;
    }

    private void Update()
    {
        Init();
        
        float distanceToStart = Vector2.Distance(transform.position, startPosition);
        if (distanceToStart >= maxDistance)
        {

            gameObject.SetActive(false); // Deactivate the object
        }

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
        rb2d.velocity = transform.up * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        for (int i = 0; i < allowedLayers.Length; i++)
        {
            // Ki?m tra xem va ch?m c� x?y ra v?i c�c layer ???c cho ph�p
            if (((1 << collision.gameObject.layer) & allowedLayers[i].value) != 0)
            {
                // X? l� va ch?m ? ?�y
                DisableObject();
                String name_layer = LayerMask.LayerToName(collision.gameObject.layer);
                if (name_layer == "enemies"|| name_layer == "player")
                {
                    healt = collision.gameObject.GetComponent<Health>();
                    healt.TakeDamage(damage);
                }
        
                Effect_Manager.instance.SpawnVFX("Particle Explosion", transform.position, Quaternion.identity);
                Effect_Manager.instance.SpawnVFX("Prefab Explosion", transform.position, Quaternion.identity);
                
            }
        }


        if (collision.gameObject.CompareTag("boom"))
        {
            collision.gameObject.GetComponent<BomEvent>().DecreaseCD(1f);

        }
    }





}
