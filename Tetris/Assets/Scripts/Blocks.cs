using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private float lastTime = 0;
    private float timeInterval = 1.0f;
    private bool isActive = true;


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


    //자유낙하
    private void drop()
    {
        var GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();

        if (Time.time - lastTime >= timeInterval)
        {
            transform.position += Vector3.down;
            lastTime = Time.time;
        }


        //이동후 범위를 초과 확인
        if (!StageManager.checkBlocks(transform))
        {
            //이동 범위를 초과했을 경우 이동 전으로 복구
            transform.position += new Vector3(0, 1, 0);
            //새로운 블럭 생성
            GM.isSpawning = false;
            transform.parent = null;
            StageManager.updtaeBlocksInfo(transform);
            this.enabled = false;
        }

        if (StageManager.checkeCollision(transform))
        {
            //이동 범위를 초과했을 경우 이동 전으로 복구
            transform.position += new Vector3(0, 1, 0);
            //새로운 블럭 생성
            transform.parent = null;
            GM.isSpawning = false;
            StageManager.updtaeBlocksInfo(transform);
            this.enabled = false;
        }

        StageManager.updtaeBlocksInfo(transform);

    }


    //좌우 이동
    private void horizontalMove(bool direction)
    {
        //입력에 따른 이동
        if(direction == true)
            transform.position += new Vector3(-1, 0, 0);
        else
            transform.position += new Vector3(1, 0, 0);


        //이동후 범위를 초과 확인
        if (!StageManager.checkBlocks(transform))
        {
            if (direction == true)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position += new Vector3(-1, 0, 0);
            StageManager.updtaeBlocksInfo(transform);
        }

        if (StageManager.checkeCollision(transform))
        {
            if (direction == true)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position += new Vector3(-1, 0, 0);
            StageManager.updtaeBlocksInfo(transform);
        }

        StageManager.updtaeBlocksInfo(transform);
    }       


    //회전
    private void rotationalMove()
    {
        transform.Rotate(0, 0, -90);
        //이동후 범위를 초과 확인
        if (!StageManager.checkBlocks(transform))
        {
            transform.Rotate(0, 0, 90);
            StageManager.updtaeBlocksInfo(transform);
        }

        if (StageManager.checkeCollision(transform))
        {
            transform.Rotate(0, 0, 90);
            StageManager.updtaeBlocksInfo(transform);
        }

        StageManager.updtaeBlocksInfo(transform);
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
        StageManager.updtaeBlocksInfo(transform);
        isActive = false;
    }

}
