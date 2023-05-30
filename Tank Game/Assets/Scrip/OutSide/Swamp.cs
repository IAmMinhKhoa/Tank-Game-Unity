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
        }
        if (otherRigidbody != null && tag_object == "Enemies_AI")
        {
            AIPath aipath_tank = coll.gameObject.GetComponent<AIPath>();
            default_speed_object_AI  =aipath_tank.maxSpeed;
            aipath_tank.maxSpeed = 0.2f;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        Rigidbody2D otherRigidbody = coll.gameObject.GetComponent<Rigidbody2D>();
        AIPath aipath_tank = coll.gameObject.GetComponent<AIPath>();
        if (otherRigidbody != null )
        {
            otherRigidbody.drag = 0f;
           
          
        }
        if (aipath_tank != null)
        {
            aipath_tank.maxSpeed = default_speed_object_AI;
        }
    }
  
}
