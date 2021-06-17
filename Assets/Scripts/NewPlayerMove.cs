using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{
    public float speed;
    // public float drop = 20f;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public Vector3 jump;

    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Road")
        {
            isGrounded = true;
        }
        else if (player.gameObject.tag == "Obstacle")
        {
            isGrounded = true;
        }
    }

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
        else if (Input.GetKey("w") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        //else if (Input.GetKey("s"))
        //{
        //    transform.position -= transform.TransformDirection(Vector3.down) * Time.deltaTime * drop;
        //    Debug.Log("Desceu");
        //}
    }












}
