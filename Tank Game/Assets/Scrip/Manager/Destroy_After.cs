using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_After : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

}
