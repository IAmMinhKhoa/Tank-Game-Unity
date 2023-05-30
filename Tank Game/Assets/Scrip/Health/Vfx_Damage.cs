using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vfx_Damage : MonoBehaviour
{

   

    void Start()
    {
        // Tính toán v? trí m?i
        //Vector2 destination = new Vector2(transform.position.x, transform.position.y + destinationY);
    }

    void Update()
    {
        // float step = speed * Time.deltaTime;
        // transform.position = Vector2.Lerp(transform.position, destination, step);
        //  Debug.Log(transform.position.x);
        // transform.position = new Vector3(transform.position.x , transform.position.y+0.01f, transform.position.z);
        /* Vector3 upDirection = transform.TransformDirection(Vector3.up);
         transform.position += upDirection * 0.01f;*/
        Vector3 globalUp = Vector3.up;
        Vector3 localUp = transform.up;
        Vector3 currentPosition = transform.position;

        // Chuy?n ??i v? trí hi?n t?i t? h? t?a ?? c?c b? sang h? t?a ?? toàn c?c
        Vector3 globalPosition = transform.TransformPoint(currentPosition);

        // C?ng vector up c?a h? t?a ?? toàn c?c ?? t?o ra v? trí m?i
        Vector3 newPosition = globalPosition + globalUp * 0.008f;

        // Chuy?n ??i v? trí m?i t? h? t?a ?? toàn c?c sang h? t?a ?? c?c b?
        Vector3 newLocalPosition = transform.InverseTransformPoint(newPosition);

        // Thi?t l?p v? trí m?i cho ??i t??ng
        transform.position = newLocalPosition;
    }

}
