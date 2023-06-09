using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent OnShoot =new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    public Camera maincamera;
    private void Awake()
    {
         maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        maincamera.GetComponent<CinemachineVirtualCamera>().Follow=this.transform;

    }

    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButton(0))
        {
            OnShoot?.Invoke();
             
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mouseposition=Input.mousePosition;
        mouseposition.z = maincamera.nearClipPlane;
        Vector2 mouseworldposition = maincamera.ScreenToWorldPoint(mouseposition);
    

        return mouseworldposition;
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        OnMoveBody?.Invoke(movementVector.normalized);
        
    }
}
