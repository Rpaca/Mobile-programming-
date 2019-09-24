using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DistanceCalcurator : MonoBehaviour
{
    public List<GameObject> foundObjects;
    public string tagName;
    public GameObject enemy;
    public float shortDistance;
    public Text objText;
    public Text distanceText;


    void Update()
    {
        foundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
        shortDistance = Vector3.Distance(gameObject.transform.position, foundObjects[0].transform.position);

        enemy = foundObjects[0]; 

        foreach (GameObject found in foundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDistance) 
            {
                enemy = found;
                shortDistance = Distance;
            }
        }

        objText.text = "가장 가까운 적 : " + enemy.name;
        distanceText.text = "적과의 거리: " + shortDistance;
    }
}

