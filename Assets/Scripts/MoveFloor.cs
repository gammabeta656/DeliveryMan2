using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float speed = 20.0f;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
