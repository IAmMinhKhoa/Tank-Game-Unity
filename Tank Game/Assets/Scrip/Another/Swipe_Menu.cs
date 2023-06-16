using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_Menu : MonoBehaviour
{
    public GameObject scrollBar;
    float scroll_pos=0;
    float[] pos;
   
    // Update is called once per frame
    void Update()
    {
        pos=new float[TransformBlock.childCount];
    }
}
