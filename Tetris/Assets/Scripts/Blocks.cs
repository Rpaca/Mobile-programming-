using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private float lastTime = 0;
    private float timeInterval = 1.5f;
    private bool isActive = true;
    private GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        drop();

        if (isActive == false)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            horizontalMove(true);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            horizontalMove(false);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rotationalMove();
        if (Input.GetKey(KeyCode.DownArrow))
            speedUp(true);
        if (Input.GetKeyUp(KeyCode.DownArrow))
            speedUp(false);
        if (Input.GetKeyDown(KeyCode.Space))
            instantDrop();

  

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blocks")
        {
            print("crush");
            GetComponent<Blocks>().enabled = false;
        }
    }


    //자유낙하
    private void drop()
    {
        //바닥에 도착했는지 확인
        if (transform.position.y == 0)
        {
            GM.isSpawning = false;
            return;
        }

        if (Time.time - lastTime >= timeInterval)
        {
            transform.position += Vector3.down;
            lastTime = Time.time;
        }
    }

    //좌우 이동
    private void horizontalMove(bool direction)
    {
        //충돌했는지 확인

        //아닐시
        if(direction == true)
            transform.position += Vector3.left;
        else
            transform.position += Vector3.right;
    }       


    //회전
    private void rotationalMove()
    {
        transform.Rotate(0, 0, -90);
    }

    //스피드 업
    private void speedUp(bool onActive)
    {
        timeInterval = 1.5f;
        if (onActive == true)
            timeInterval = 0.1f;
    }

    //즉시낙하
    private void instantDrop()
    {
        timeInterval = 0;
        isActive = false;
    }
}
