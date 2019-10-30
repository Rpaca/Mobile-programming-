using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int stageWidth = 10;// 스테이지 가로 크기
    [SerializeField]
    private int stageHeight = 20;// 스테이지 세로 크기
    [SerializeField]
    private GameObject[] stageBlocks = new GameObject[2];//스테이지 블록 오브젝트

    //블록의 위치정보가 저장되는 이차원 배열
    private Transform[,] tile;
    private ScoreManager Score;

    private void Start()
    {
        tile = new Transform[stageWidth, stageHeight];
        Score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        buildStage();
    }


    //스테이지 생성
    private void buildStage()
    {
        int i = 0; // 격자 무늬를 만들기 위한 변수
        for (int y = 0; y < stageHeight; y++)
        {
            i++;
            for (int x = 0; x < stageWidth; x++)
            {
                i++;
                var stageBlock = stageBlocks[0];
                if(i % 2 == 0)
                    stageBlock = stageBlocks[1];
                Instantiate(stageBlock);
                stageBlock.transform.position = new Vector3(x, y, 0);
            }
        }
    }


    //position 값을 반올림한 값으로 변환
    private Vector3 roundVec3(Vector3 pos)
    {
       return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
    }

    //블록이 스테이지 안에 있는지 확인
    private bool isInStage(Vector3 pos)
    {
        return (pos.x >= 0 && pos.x < stageWidth && pos.y >= 0);
    }


    //블록이 게임 스테이지를 벗어났는지 확인
    public bool IsValidTranslate(Transform blocks)
    {
        foreach (Transform child in blocks)
        {
            if (child.name == "Block")
            {
                Vector3 pos = roundVec3(child.position);
                if (!isInStage(pos))
                    return false;

                //잘못된 위치에 생성도리 경우
                if ((int)pos.x >= stageWidth || (int)pos.y >= stageHeight)
                    return false;

                //블록이 다른 블록과 충돌하는지 확인
                if (tile[(int)pos.x, (int)pos.y] != null
                   && tile[(int)pos.x, (int)pos.y].parent != blocks)
                    return false;
            }
        }
        return true;
    }

    //한줄이 가득 찼는지 확인
    private bool isLineFull(int y)
    {
        int bloksCounter = 0;
        for (int x = 0; x < stageWidth; x++)
        {
            if (tile[x, y] != null)
                bloksCounter++;
        }
        if (bloksCounter == 10)
            return true;
        return false;
    }

    //한줄을 삭제
    private void desroyLine(int y)
    {
        for (int x = 0; x < stageWidth; x++)
        {
            Destroy(tile[x, y].gameObject);
            tile[x, y] = null;
        }
    }


    //타일 삭제후 한칸씩 위치 이동
    private void downBlocks(int pos)
    {
        for (int y = pos; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                if (tile[x, y] != null)
                {
                    tile[x, y].gameObject.transform.position += new Vector3(0, -1, 0);
                    tile[x, y - 1] = tile[x, y];
                    //print(tile[x, y - 1].gameObject.transform.position);
                    tile[x, y] = null;
                }
            }
        }
    }

    //타일 삭제
    public void DestroyBlocks()
    {
        int score = Score.GetScore();
        for (int y = 0; y < stageHeight; y++)
        {
            if (isLineFull(y))
            {
                desroyLine(y);
                downBlocks(y + 1);
                Score.AddScore();
                y--;
            }
        }
        //점수가 증가가 없으면 콤보 초기화 아니면 콤보 증가
       if (score == Score.GetScore())
            Score.ResetCombo();
        else
            Score.AddCombo();

    }



    //타일 정보 업데이트
    public void UpdtaeBlocksInfo(Transform blocks)
    {
        //이동전 좌표 삭제
        for (int y = 0; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                if (tile[x, y] != null)
                {
                    if (tile[x, y].parent == blocks)
                        tile[x, y] = null;
                }
            }
        }

        //블록 좌표정보 업데이트
        foreach (Transform child in blocks)
        {
            if (child.name == "Block")
            {
                Vector3 pos = roundVec3(child.position);
                tile[(int)pos.x, (int)pos.y] = child;
                //print(pos.x + "," + pos.y);
            }
        }
    }


    //지금 스테이지에 블록을 생성할수 있는지 확인

    public bool IsSpawneble(Vector3 pos)
    {
        Vector3 v = roundVec3(pos);
        if (tile[(int)pos.x, (int)pos.y] != null)
            return false;
        return true;
    }

}
