using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent OnDeath;
    public int maxHealth = 2;
    public int minHealth = 0;
    public int currentHealth;

    public GameObject model1;
    public GameObject model2;
    private GameObject currentModel;


    void Start()
    {
        currentHealth = maxHealth;
        currentModel = Instantiate(model1, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        currentModel.transform.parent = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Damage(1);
            
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("GameOver");
                OnDeath.Invoke();
            }
        }
    }

    void Damage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 1)
        {
            GameObject thisModel = Instantiate(model2, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
            Destroy(currentModel);
            thisModel.transform.parent = transform;
            currentModel = thisModel;
        }
        else if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            OnDeath.Invoke();
        }

    }



    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            Debug.Log("-1HP");
            Damage(1);
        }
    }
}
