using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public List<GameObject> Boxes;
    public List<GameObject> Bag;
    public float boxSize = 3.0f;

    public void StackBoxes()
    {
        GameObject gameobj;
        gameobj = Instantiate(Boxes[0]) as GameObject;
        gameobj.transform.SetParent(transform);

        if (Bag.Count > 0)
        {
            GameObject last = Bag[Bag.Count - 1];
            gameobj.transform.localPosition = last.transform.localPosition + new Vector3(0, boxSize, 0);
        }
        else
        {
            gameobj.transform.localPosition = Vector3.zero;
        }

        Bag.Add(gameobj);
    }

    public void DestroyBoxes()
    {
        Bag.RemoveAt(Bag.Count - 1);
    }


    public void OnTriggerEnter(Collider delivery)
    {
        if (delivery.gameObject.tag == "Restaurant")
        {
            StackBoxes();
            Debug.Log("Recebeu");
        }
        else if (delivery.gameObject.tag == "Client")
        {
            DestroyBoxes();
            Debug.Log("Entregou");
        }
    }


}
