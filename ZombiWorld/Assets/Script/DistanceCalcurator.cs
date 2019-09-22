using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalcurator : MonoBehaviour
{
    public List<GameObject> foundObjects;
    public GameObject enemy;
    public string tagName;
    public float shortDis;


    void Update()
    {
        foundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
        shortDis = Vector3.Distance(gameObject.transform.position, foundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

        enemy = foundObjects[0]; // 첫번째를 먼저 

        foreach (GameObject found in foundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        Debug.Log(enemy.name);
        Debug.Log(shortDis);
    }
}

