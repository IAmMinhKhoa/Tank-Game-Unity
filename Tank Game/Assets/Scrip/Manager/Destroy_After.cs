using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy_After : MonoBehaviour
{
    //allow destroy or setactive false this object 
    public float time;
    public bool allowActive;
    void OnEnable ()
    {
        if(allowActive!=true){
            Destroy(this.gameObject, time);
        }else
        {
            StartCoroutine(ActivateGameObject(time));
        } 
    }
   
     protected IEnumerator ActivateGameObject(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
