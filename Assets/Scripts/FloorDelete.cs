using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorDelete : MonoBehaviour
{
    public UnityEvent OnFloorDeleted;

    public void OnTriggerEnter(Collider delete)
    {
        if (delete.gameObject.tag == "Floor")
        {
            Destroy(delete.gameObject);
            OnFloorDeleted.Invoke();
        }
    }

}
