using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask[] allowedLayers;
    protected Health healt;
    public int damage = 30;
    private void Start()
    {
        Sound_Manager.instance.PlaySound(SoundType.Explosion);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int i = 0; i < allowedLayers.Length; i++)
        {
            // Ki?m tra xem va ch?m c� x?y ra v?i c�c layer ???c cho ph�p
            if (((1 << collision.gameObject.layer) & allowedLayers[i].value) != 0)
            {
                String name_layer = LayerMask.LayerToName(collision.gameObject.layer);
                
                if (name_layer == "enemies" || name_layer == "player")
                {

                    healt = collision.gameObject.GetComponent<Health>();
                    healt.TakeDamage(damage);
                }
            }
        }
        if (collision.tag== "Player")
        {
            healt = collision.gameObject.GetComponent<Health>();

            
            healt.TakeDamage(damage);

        }
    }
}
