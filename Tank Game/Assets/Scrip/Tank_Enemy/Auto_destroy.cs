using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_destroy : MonoBehaviour
{
    public float time = 10;
    IEnumerator DestroyAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterDelay(this.gameObject));
    }
   

}
