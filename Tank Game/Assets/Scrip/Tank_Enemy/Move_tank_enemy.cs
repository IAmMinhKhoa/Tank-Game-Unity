using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move_tank_enemy : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed;
    public List<Transform> pathPoints;
    public float time_rotation = 2f;
    private int currentPoint = 0;
    private Rigidbody2D rb;
    private bool check_rotation = false;

    void Start()
    {
        gameObject.transform.position = pathPoints[0].position;

        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {

        Vector2 targetPosition = pathPoints[currentPoint].position;
        Vector2 currentPosition = rb.position;


        Doing_Rotation_Run(currentPosition, targetPosition);
        distance_tank_next_point(currentPosition, targetPosition);



    }


    void Doing_Rotation_Run(Vector2 currentPosition, Vector2 targetPosition)
    {

        Quaternion rotaiton_turret = Quaternion.FromToRotation(Vector2.up, currentPosition - targetPosition);
        Vector2 direction = (targetPosition - currentPosition).normalized;

        if (check_rotation)
        {
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotaiton_turret, rotationSpeed * Time.deltaTime);
        }
        if (check_rotation == false)
            rb.velocity = direction * speed;

    }

    void distance_tank_next_point(Vector2 current,Vector2 target)
    {
        if (Vector2.Distance(current, target) < 0.05f)
        {
            StartCoroutine(rotation_turet(time_rotation));
            currentPoint = (currentPoint + 1) % pathPoints.Count;
        }
    }

    IEnumerator rotation_turet(float time_rotation)
    {
        check_rotation = true;
        yield return new WaitForSeconds(time_rotation);
        check_rotation = false;
    }
}