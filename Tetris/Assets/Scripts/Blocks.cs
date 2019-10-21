using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    private float speed = 1.0f;
    private float lastTime = 0;
    private float speedTime = 0.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        moveDown();

	}

    private void moveDown()
    {
        //바닥에 떨어질때가지 계속 떨어짐
        if (transform.position.y == 0)
            return;
        if (Time.time - lastTime >= speedTime)
        {
            transform.position += Vector3.down;
            lastTime = Time.time;
        }
    }
}
