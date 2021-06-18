using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public List<GameObject> Boxes;
    public List<GameObject> Bag;
    public float boxSize = 2.0f;
    public float timer = 1.0f;
    public bool recebeuCaixa;
    public bool entregouCaixa;
    public float timerMax = 1.0f;
    public Collider deliveryVar;
    public int index;
    public GameObject caixaRef;
    public GameObject playerPosition;

    public void StackBoxes()
    {
        GameObject gameobj;
        gameobj = Instantiate(Boxes[0]) as GameObject;
        gameobj.transform.SetParent(transform);

        if (Bag.Count > 0)
        {
            GameObject last = Bag[Bag.Count - 1];
            gameobj.transform.localPosition = last.transform.localPosition + new Vector3(0, 1, 0);
        }
        else
        {
            gameobj.transform.localPosition = Vector3.zero;
        }

        Bag.Add(gameobj);
    }

    private void Update()
    {
       if (recebeuCaixa == true || entregouCaixa == true)
       {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
       
       if (timer <= 0)
       {
            EnableCollider(deliveryVar);
            timer = timerMax;

            if (recebeuCaixa)
            {
                recebeuCaixa = false;
            }

            if (entregouCaixa)
            {
                entregouCaixa = false;
            }
       }
    }

    public void DestroyBoxes()
    {

        Destroy(Bag[Bag.Count - 1]);
        Bag.RemoveAt(Bag.Count - 1);
    }


    public void OnTriggerEnter(Collider delivery)
    {
        deliveryVar = delivery;
        if (delivery.gameObject.tag == "Restaurant")
        {
            StackBoxes();
            Debug.Log("Recebeu");

            recebeuCaixa = true;

            DisableCollider(deliveryVar);
        }
        else if (delivery.gameObject.tag == "Client")
        {
            DestroyBoxes();
            Debug.Log("Entregou");

            entregouCaixa = true; 

            DisableCollider(deliveryVar);
        }

        
    }

    public void EnableCollider(Collider delivery)
    {
        delivery.enabled = true;
    }

    public void DisableCollider(Collider delivery)
    {
        delivery.enabled = false;
    }
}

