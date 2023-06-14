using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : MonoBehaviour
{
    public int val_heal=20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sound_Manager.instance.PlaySound(SoundType.PickUp);
            Health health = collision.gameObject.GetComponent<Health>();
            Effect_Manager.instance.SpawnVFX("Prefab Eat Item Lightning", transform.position, Quaternion.identity); 
            health.Heal(val_heal);
            Destroy(gameObject);
        }
    
    }
   
}
