using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMarksSpawner : MonoBehaviour
{
    private Vector2 lastPosition;
    public float trackDistance = 0.3f;
    public GameObject trackPrefab;
    public int objectPoolSize = 50;
    private ObjectPool objectpool;


    private void Awake()
    {
        objectpool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        lastPosition = transform.position;
        objectpool.Innit(trackPrefab, objectPoolSize);
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, lastPosition);

        if (distance >= trackDistance)
        {
            lastPosition=transform.position;
            var tracks = objectpool.CreateObject();
            tracks.transform.position = transform.position;
            tracks.transform.rotation = transform.rotation;
        }
    }

}
