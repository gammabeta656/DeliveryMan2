using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed;
        }
        else if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * speed; 
        }
    }












}
