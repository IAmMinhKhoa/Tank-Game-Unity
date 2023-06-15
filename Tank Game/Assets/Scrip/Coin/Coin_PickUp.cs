using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_PickUp : MonoBehaviour
{
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Coin_Manager manager = Coin_Manager.instance;
            if (manager != null)
            {
                Sound_Manager.instance.PlaySound(SoundType.PickUp);
                Effect_Manager.instance.SpawnVFX("Prefab Eat Item", transform.position, Quaternion.identity);
                manager.coin += value;
                Destroy(gameObject);
            }
        }
    }
}
