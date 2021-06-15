using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] floorprefabs;
    public List<GameObject> CurrentFloors;
    
    private float floorLength = 34.2f;
    private int Floorsrend = 20;
    private int lastPrefabIndex = 0;
    
    void Start()
    {
        for (int i = 0; i < Floorsrend; i++)
        {
            GenerateFloor();
        }
    }

    private void GenerateFloor()
    {
        GameObject gameobj;
        gameobj = Instantiate(floorprefabs[RandomPrefabIndex()]) as GameObject;
        
        if(CurrentFloors.Count > 0)
        {
            GameObject last = CurrentFloors[CurrentFloors.Count - 1];
            gameobj.transform.position = last.transform.position + new Vector3(0, 0, floorLength);
        }
        else
        {
            gameobj.transform.position = Vector3.zero;
        }

        CurrentFloors.Add(gameobj);
    }

    private int RandomPrefabIndex()
    {
        if (floorprefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, floorprefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    public void OnFloorDeleted()
    {
        CurrentFloors.RemoveAt(0);
        GenerateFloor();
    }

    public void StopFloors()
    {
        foreach(GameObject floor in CurrentFloors)
        {
            floor.GetComponent<MoveFloor>().enabled = false;
        }
    }
}
