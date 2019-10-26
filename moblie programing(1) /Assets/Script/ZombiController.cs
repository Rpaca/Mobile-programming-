using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiController : MonoBehaviour {

    private GameObject player; //private을 명시하지 않으면 internal로 결국 private와 동일함

    private ZombiSpawner zobieSpawner; //맴버변수는 소문자로

    float speed = 0.05f;

	// Use this for initialization
	void Start ()
    {
        //target = GameObject.FindGameObjectsWithTag(tagName);
        player = GameObject.Find("Player");
        zobieSpawner = GameObject.Find("Main Camera").GetComponent<ZombiSpawner>();

        /*
        var mainCamera = GameObject.Find("MainCamera");
        if (mainCamera)
            zobieSpawner = GetComponent<ZombiSpawner>();
        */ //위와 동일
    }

    // Update is called once per frame
    void Update ()
    {
        if (!player) return;

        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 1.0f) //빠져나가는 상황을 먼저 계산하는 것이 좋음
        {
            //Destroy(this.gameObject); //note Destroy(this);
            zobieSpawner.destroyMe(this.gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed); //player에 있는 맴버 변수 transform의 캐쉬이용
    }
}