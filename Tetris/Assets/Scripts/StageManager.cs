using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private static int stageWidth = 10;
    [SerializeField]
    private static int stageHeight = 20;
    // 타일이 없는 경우 null
    private static Transform[,] tile = new Transform[10, 20];


   static private Vector3 roundVec3(Vector3 vec)
    {
        return new Vector3(Mathf.Round(vec.x), Mathf.Round(vec.y));
    }

    //블록 범위 확인
    private static bool checkBorder(Vector3 pos)
    {
        //print(Mathf.Round(pos.y));
        //if ((int)pos.x < 0)
        // print((int)pos.x);
        if ((int)pos.y < 0)
        {
            //print(pos.y);
           // print((int)pos.y);
        }
        return (pos.x >= 0 && pos.x < stageWidth && pos.y >= 0);
    }

    //블록 범위 확인 블록별 적용
    public static bool checkBlocks(Transform transform)
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Block")
            {
                Vector3 pos = roundVec3(child.position);
                if (!checkBorder(pos))
                {
                    return false;
                }
            }
        }
        return true;
    }

    //타일 삭제
    public static void destroyBlocks()
    {
        int score = Score.GetScore();
        int bloksCounter = 0;
        for (int y = 0; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                if (tile[x, y] != null)
                    bloksCounter++;
            }
            if (bloksCounter == 10)
            {
                for (int x = 0; x < stageWidth; x++)
                {
                    Destroy(tile[x, y].gameObject);
                    tile[x, y] = null;
                }
                downBlocks(y+1);
                Score.addScore();
                y--;
            }
            bloksCounter = 0;
        }
        //타일 삭제 확인 전과 후를 비교해서 ADDSOCRE가 사용되었으면 COMB++ 아니면 초기화
        if (score == Score.GetScore())
            Score.resetCombo();
        else
            Score.addCombo();
    }

    //타일 삭제후 한칸씩 위치 이동
    private static void downBlocks(int pos)
    {
        for (int y = pos; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                if (tile[x, y] != null)
                {
                    tile[x, y].gameObject.transform.position += new Vector3(0, -1, 0);
                    tile[x, y - 1] = tile[x, y];
                    print(tile[x, y - 1].gameObject.transform.position);
                    tile[x, y] = null;
                }
            }
        }
    }


    //타일 정보 업데이트
   static  public void updtaeBlocksInfo(Transform blocks)
    {

        for (int y = 0; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                // null은 아닌데 그 정보가 지금 이동하는 블록이면 null로 취급
                if (tile[x, y] != null)
                {
                    if (tile[x, y].parent == blocks)
                        tile[x, y] = null;
                }
            }
        }

       // null 이면 업데이트
        foreach (Transform child in blocks)
        {
            if (child.name == "Block")
            {
                Vector3 pos = roundVec3(child.position);
                tile[(int)pos.x, (int)pos.y] = child;
            }
        }
    }

    //블록이 다른 블록과 충돌하는지 확인(블록이 이미 있으면 true 없으면 false)
    static public bool checkeCollision(Transform blocks)
    {
        //블록이 이미 있는데 그게 이블록이 아니면 return true
        foreach (Transform child in blocks)
        {
            //print(tile[(int)child.position.x, (int)child.position.y]);
            if (child.name == "Block")
            {
                Vector3 pos = roundVec3(child.position);
                if (tile[(int)pos.x, (int)pos.y] != null
                    && tile[(int)pos.x, (int)pos.y].parent != blocks)
                {
                    print("crush");
                    return true;
                }
            }
        }

        return false;
    }


}
