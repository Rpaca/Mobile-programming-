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

    //블록 범위 확인
    private static bool checkBorder(Vector3 pos)
    {
        return (pos.x >= 0 && pos.x < stageWidth && pos.y >= 0);
    }

    //블록 범위 확인 블록별 적용
    public static bool checkBlocks(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = child.position;
            if (!checkBorder(pos))
                return false;
        }
        return true;
    }

    //타일 삭제
    private void destroyBlocks()
    {
        int bloksCounter = 0;
        for (int y = 0; y < stageHeight; y++)
        {
            for (int x = 0; x < stageWidth; x++)
            {
                if (tile[x, y] != null)
                    bloksCounter++;
            }
            print(bloksCounter);
            if (bloksCounter == 10)
            {
                for (int x = 0; x < stageWidth; x++)
                {
                    Destroy(tile[x, y].gameObject, 1);
                    tile[x, y] = null;
                }
            }
            bloksCounter = 0;
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
            //"if" is not called why?
            if(child.name == "Block")
                tile[(int)child.position.x, (int)child.position.y] = child;
        }
    }

    //블록이 다른 블록과 충돌하는지 확인(블록이 이미 있으면 true 없으면 false)
    static public bool checkeCollision(Transform blocks)
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
        

        //블록이 이미 있는데 그게 이블록이 아니면 return true
        foreach (Transform child in blocks)
        {
            //print(tile[(int)child.position.x, (int)child.position.y]);
            if (child.name == "Block")
                if (tile[(int)child.position.x, (int)child.position.y] != null)
                    return true;
        }

        // null 이면 업데이트
        foreach (Transform child in blocks)
        {
            if (child.name == "Block")
                tile[(int)blocks.position.x, (int)blocks.position.y] = child;
        }

        return false;
    }


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        destroyBlocks();

    }
}
