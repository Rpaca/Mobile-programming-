using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blocks = new GameObject[7]; //생성할 블록
    private GameObject nextBlocks; //다음에 생성될 블록
    private int indexOfBlocsk = -1; // 다음에 생성될 블록 모양
    private bool isSpawned = false;

    private StageManager Stage;
    private GameManager GM;

    void Awake()
    {
        Stage = GameObject.Find("GameManager").GetComponent<StageManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update ()
    {
        spawn();		
	}

    //블록 생성
    private void spawn()
    {
        //블록을 생성했는지 확인
        if(isSpawned) return;

        //블록을 생성할 공간이 있는지 확인
        if (!Stage.IsSpawneble(this.gameObject.transform.position))
        {
            GM.GameOver();
            return;
        }


        GameObject newBlocks; //생성된 블록
        Vector3 pos = this.gameObject.transform.position;

        if (indexOfBlocsk < 0) //처음 블록을 생성할 경우
          newBlocks = Instantiate(blocks[Random.Range(0, blocks.Length)], pos, Quaternion.identity);
        else
          newBlocks = Instantiate(blocks[indexOfBlocsk], pos, Quaternion.identity);

        createNextBlocks();
        isSpawned = true;
    }

    //다음에 나올 블록을 미리 생성
    private void createNextBlocks()
    {
        Destroy(nextBlocks);
        Vector3 pos = new Vector3(21.0f, 15.5f, -1.0f); //nextBlockInfo UI 좌표
        indexOfBlocsk = Random.Range(0, blocks.Length);
        nextBlocks = Instantiate(blocks[indexOfBlocsk], pos, Quaternion.identity);
        nextBlocks.GetComponent<BlocksController>().enabled = false;
    }

    public void TurnOnSpawner()
    {
        isSpawned = false;
    }

}
