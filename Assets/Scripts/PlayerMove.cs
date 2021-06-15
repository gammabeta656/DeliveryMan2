using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 jump;
    //tw
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(-3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
