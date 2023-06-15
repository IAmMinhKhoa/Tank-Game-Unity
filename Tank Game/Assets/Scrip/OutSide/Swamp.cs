using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    public int adj_Swamp = 999;
    float default_speed_object_AI;
    void OnTriggerEnter2D(Collider2D coll)
    {
        Rigidbody2D otherRigidbody = coll.gameObject.GetComponent<Rigidbody2D>();

        string tag_object = coll.gameObject.tag.ToString();
        if (otherRigidbody != null &&tag_object!="bullets")
        {
            otherRigidbody.drag = adj_Swamp;
            Sound_Manager.instance.PlaySound(SoundType.Swamp);
        }
        if (otherRigidbody != null && tag_object == "enemies")
        {
            AIPath aipath_tank = coll.gameObject.GetComponent<AIPath>();
            if (aipath_tank != null) {
                default_speed_object_AI = aipath_tank.maxSpeed;
                aipath_tank.maxSpeed = 0.2f;
                Sound_Manager.instance.PlaySound(SoundType.Swamp);
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        Rigidbody2D otherRigidbody = coll.gameObject.GetComponent<Rigidbody2D>();
        AIPath aipath_tank = coll.gameObject.GetComponent<AIPath>();
        if (otherRigidbody != null )
        {
            otherRigidbody.drag = 0f;

            Sound_Manager.instance.StopSound(SoundType.Swamp);
        }
        if (aipath_tank != null)
        {
            Sound_Manager.instance.StopSound(SoundType.Swamp);
            aipath_tank.maxSpeed = default_speed_object_AI;
        }
    }
  
}
