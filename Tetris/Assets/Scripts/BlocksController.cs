using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{ 
    private float timer = 0.0f; //타이머
    private float timeInterval = 0.8f; //기본 블록 이동 속도
    private float lastspeed = 0.8f; //변화한 이동 속도

    StageManager Stage;
    BlocksSpawner Spawner;
    ScoreManager Score;

    private void Awake()
    {
        Stage = GameObject.Find("GameManager").GetComponent<StageManager>();
    }

    void Start()
    {
        Stage = GameObject.Find("GameManager").GetComponent<StageManager>();
        Score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        Spawner = GameObject.Find("BlocksSpawner").GetComponent<BlocksSpawner>();

        setSpeed();
        print(lastspeed);
    }

    void Update()
    {
        drop();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            horizontalMove(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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

    //레벨에 따라 속도 변경
    private void setSpeed()
    {
        lastspeed -= Score.GetLevel() * 0.15f;
        if (lastspeed >= 0.2)
            timeInterval = lastspeed;
        else
            timeInterval = 0.2f;
    }


    //자유낙하
    private void drop()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            transform.position += new Vector3(0, -1, 0);
            timer = 0;
        }

        //이동후 범위를 초과 확인
        if (!Stage.IsValidTranslate(this.transform))
        {
            //이동 범위를 초과했을 경우 이동 전으로 복구
            transform.position += new Vector3(0, 1, 0);
            Stage.UpdtaeBlocksInfo(transform); //자식 정보 업데이트
            Stage.DestroyBlocks(); // 라인 삭제 확인
            Spawner.TurnOnSpawner();//Spawner 재활성화
            transform.DetachChildren(); //부모 자식 관계 해제
            Destroy(this.gameObject); //부모 삭제
        }

        Stage.UpdtaeBlocksInfo(transform);

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
        if (!Stage.IsValidTranslate(this.transform))
        {
            print("범위를 나감");
        
            if (direction == true)
                transform.position += new Vector3(1, 0, 0);
            else
                transform.position += new Vector3(-1, 0, 0);
            Stage.UpdtaeBlocksInfo(transform);
        }

       Stage.UpdtaeBlocksInfo(transform);
    }       


    //회전
    private void rotationalMove()
    {
        Transform rotationPivot; // 회전 중심축
        rotationPivot = transform.Find("Pivot");

        transform.RotateAround(rotationPivot.position, Vector3.forward, -90.0f);
        //이동후 범위를 초과 확인
        if (!Stage.IsValidTranslate(this.transform))
        {
            transform.RotateAround(rotationPivot.position, Vector3.forward, 90.0f);
           Stage.UpdtaeBlocksInfo(transform);
        }
        Stage.UpdtaeBlocksInfo(transform);
    }

    //낙하 속도 증가
    private void speedUp(bool onActive)
    {
        timeInterval = lastspeed; 
        if (onActive == true)
            timeInterval = 0.1f;
    }

    //즉시낙하
    private void instantDrop()
    {
        timeInterval = 0;
    }



}
