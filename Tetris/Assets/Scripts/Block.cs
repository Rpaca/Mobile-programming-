using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        moveDown();
        moveLeft();
        moveRight();
    }

    //블록 1줄이 완성된 경우 블록을 지우는 함수
    private void Clear()
    {

    }

    //블록을 아래 방향으로 내려오게 하는 함수
    private void moveDown()
    {
        //바닥 위치가 될때가지 계속 위치가 한칸씩 내려옴
        //단, 

        //1번 그냥 trnaslate 시키는 일반적 이동
        transform.Translate(Vector3.down * Time.deltaTime);

        //2번 위치를 계속 int 1.0 씩업데이트 하고 옮기기
        //Vector3 pos;
        //pos = this.gameObject.transform.position;
        //pos.y-= 10.0f*Time.deltaTime;
        //this.gameObject.transform.position = pos;

    }

    private void moveLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left *20 *Time.deltaTime);
        }
    }
    

    private void moveRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 20 * Time.deltaTime);
        }
    }
}
