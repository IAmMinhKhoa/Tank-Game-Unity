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
                manager.coin += value;
                Destroy(gameObject);
            }
        }
    }
}
