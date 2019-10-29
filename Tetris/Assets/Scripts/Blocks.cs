using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private float lastTime = 0;
    private float timeInterval = 0.8f;
    private bool isActive = true;
    [SerializeField]
    private Transform rotationPivot;

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
            transform.position += new Vector3(0, -1, 0);
            lastTime = Time.time;
        }


        //이동후 범위를 초과 확인
        if (!StageManager.checkBlocks(transform) || StageManager.checkeCollision(transform))
        {
            //이동 범위를 초과했을 경우 이동 전으로 복구
            transform.position += new Vector3(0, 1, 0);
    
            GM.isSpawning = false; // 블록 재생성
            StageManager.updtaeBlocksInfo(transform); //자식 정보 업데이트
            transform.DetachChildren(); //부모 자식 관계 해제
            StageManager.destroyBlocks();
            Destroy(this.gameObject); //부모 삭제
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
            print("범위를 나감");
        
            if (direction == true)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position += new Vector3(-1, 0, 0);
            StageManager.updtaeBlocksInfo(transform);
        }

        if (StageManager.checkeCollision(transform))
        {
            print("충돌 발생");
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
        transform.RotateAround(rotationPivot.position, Vector3.forward, -90.0f);
        //이동후 범위를 초과 확인
        if (!StageManager.checkBlocks(transform))
        {
            transform.RotateAround(rotationPivot.position, Vector3.forward, 90.0f);
            StageManager.updtaeBlocksInfo(transform);
        }

        if (StageManager.checkeCollision(transform))
        {
            transform.RotateAround(rotationPivot.position, Vector3.forward, 90.0f);
            StageManager.updtaeBlocksInfo(transform);
        }

        StageManager.updtaeBlocksInfo(transform);
    }

    //스피드 업
    private void speedUp(bool onActive)
    {
        //코드 수정 필요
        timeInterval = 0.8f;
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
