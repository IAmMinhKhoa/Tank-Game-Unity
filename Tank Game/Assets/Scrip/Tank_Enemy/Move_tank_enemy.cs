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
    public GameObject ParenTrack;
    public GameObject Points;
    public float time_rotation = 2f;
    private int currentPoint = 0;
    private Rigidbody2D rb;
    private bool check_rotation = false;
    protected Animator[] tracks;

    void Start()
    {
        // Lấy tất cả các thành phần Transform của các đối tượng con của Points
        Transform[] childTransforms = Points.GetComponentsInChildren<Transform>();
        pathPoints = new List<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            // Kiểm tra xem thành phần Transform có thuộc về Points hay không
            if (childTransform != Points.transform)
            {
                pathPoints.Add(childTransform);
            }
        }
        gameObject.transform.position = pathPoints[0].position;
        rb = GetComponent<Rigidbody2D>();

        if (ParenTrack != null)
        {
            tracks = ParenTrack.GetComponentsInChildren<Animator>();
        }
        
        
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
        Quaternion rotation_turret = Quaternion.FromToRotation(Vector2.up, targetPosition - currentPosition);
        Vector2 direction = (targetPosition - currentPosition).normalized;
        float targetAngle = rotation_turret.eulerAngles.z;
        if (check_rotation)
        {
            AnimationTrack(false);
            rb.velocity = Vector2.zero;
            StartCoroutine(RotateTowards(targetAngle));
        }
        if (check_rotation == false)
        {
            rb.velocity = direction * speed;
            AnimationTrack(true);
        }
            
    }

    void distance_tank_next_point(Vector2 current, Vector2 target)
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

    IEnumerator RotateTowards(float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10 * Time.deltaTime);
            yield return null;
        }
    }
    void AnimationTrack(bool temp)
    {
        foreach (Animator track in tracks)
        {
            track.SetBool("track", temp);
        }
    }

}