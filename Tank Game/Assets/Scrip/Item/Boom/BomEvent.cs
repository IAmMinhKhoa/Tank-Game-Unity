using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BomEvent : MonoBehaviour
{
    public float CoolDownBom = 3;
    public TextMeshProUGUI TextCD;
    private void Start()
    {
        StartCoroutine(IECoolDownBoom(CoolDownBom));
        
    }
    private void Update()
    {
        TextCD.text = CoolDownBom.ToString();
    }
    protected IEnumerator IECoolDownBoom(float time)
    {
         CoolDownBom = time;
        while (CoolDownBom > 0)
        {
           
            CoolDownBom--;
            yield return new WaitForSeconds(1);
        }
        Effect_Manager.instance.SpawnVFX("Boom_Explosion", transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void DecreaseCD(float time)
    {
        if(CoolDownBom>0)
            CoolDownBom-=time;
    }
}
