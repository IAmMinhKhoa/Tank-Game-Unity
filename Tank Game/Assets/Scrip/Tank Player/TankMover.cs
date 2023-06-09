using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Vector2 movementVector;

    public TankMovementData movementData;

    public float currentSpeed = 0;
    public int currentForewardDirection = 1;
    int temp_Direction = -2;
    public float MaxSpeed;
    public float acceleration;
    public float speedRoataion;
    public float deacceleration;
    bool isMove=false;
    bool soundTrack=false;
    protected Animator Track_1;
    protected Animator Track_2;

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        MaxSpeed= movementData.MaxSpeed;
        acceleration = movementData.acceleration;
        speedRoataion = movementData.speedRotation;
        deacceleration = movementData.deaccelereration; 
    }
    private void Start()
    {
         Track_1 = transform.GetChild(0).GetComponent<Animator>();
         Track_2 = transform.GetChild(1).GetComponent<Animator>();
    }
    public void Move(Vector2 movementvector)
    {
        this.movementVector = movementvector;
        CalculateSpeed(movementvector);
        
        if (movementVector.y > 0)
        {
            currentForewardDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            currentForewardDirection = -1;
        }
    }

    private void CalculateSpeed(Vector2 movementvector)
    {
        if (currentForewardDirection != temp_Direction)
        {
            currentSpeed = 0;
            temp_Direction = currentForewardDirection;
        }
        if (movementvector == Vector2.zero)
        {
            isMove=false;
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        else if (Mathf.Abs(movementvector.y) > 0)
        {
            isMove=true;
            currentSpeed += acceleration * Time.deltaTime;
        }
        else 
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
       

        currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);
       
    }

    private void FixedUpdate()
    {
        Time.fixedDeltaTime = 0.01f;
        rb2d.velocity = (Vector2)transform.up * currentSpeed *currentForewardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * speedRoataion * Time.fixedDeltaTime));
        if(isMove==true && soundTrack==false){
            soundTrack=true;
            Sound_Manager.instance.PlaySound(SoundType.TankTrack);
            AnimationTrack(true);
        }
        else if(isMove==false)
        {
            AnimationTrack(false);
            soundTrack =false;
            Sound_Manager.instance.StopSound(SoundType.TankTrack);
        }
        
        
    }

    void AnimationTrack(bool temp)
    {
        Track_1.SetBool("track", temp);
        Track_2.SetBool("track", temp);
    }




}
