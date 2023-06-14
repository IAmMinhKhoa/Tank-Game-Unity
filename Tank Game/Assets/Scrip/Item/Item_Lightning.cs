using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Lightning : MonoBehaviour
{
    public float time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sound_Manager.instance.PlaySound(SoundType.PickUp);
            TankController control= collision.gameObject.GetComponent<TankController>();
            control.EatItemLightning(time);
            Effect_Manager.instance.SpawnVFX("Prefab Eat Item Lightning", transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
