using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBars : MonoBehaviour {

    //1,000개의 게임 오브젝트가 들어갈수 있는 레퍼런스 공간 생성
    private GameObject[,,] bars = new GameObject[10, 10, 10];

    private void buidBars()
    {
        for (int x = 0; x < 10; ++x)
        {
            for (int z = 0; z < 10; ++z)
            {
                int maxY = Random.Range(1, 10);
                for (int y = 0; y < maxY; ++y)
                {
                    if (bars[x, y, z] != null)
                    {
                        Destroy(bars[x, y, z]);
                        bars[x, y, z] = null;
                    }
                }
            }
        }

        //gameobject만들때 생성자 함수를 쓰지 마라? prefabs나 instance사용함
        //왜? 생성자를 사용하면 garbege값처리를 직접 해줘야함.
        //하지만 위의 다른 방법은 이미 만들어진 구조체를 이용해 자동으로 생성, 삭제를 해주시에 편리함.(gamrojbjects list)


        //밑에 상황에서 bar는 지역변수임. 여기서 bar에 생성한 gameobject를 넣지 않으면 사라져야하지만
        //사라지지 않고 남아 있음
        //그 이유는 유니티 자체 gameobjectlist에 저장되어있기에
        //따라서 삭제를 위한 위의 destory과정이 필요
        //garbege collection 개념 이해하
        for (int x = 0; x < 10; ++x)
        {
            for (int z = 0; z < 10; ++z)
            {
                int maxY = Random.Range(1, 10);
                for (int y = 0; y < maxY; ++y)
                {
                    var bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bar.transform.position = new Vector3(x, y, z);
                    bars[x, y, z] = bar;
                }
            }
        }
        //5장 내용은 위의 배열(array)까지만 다룸(2019.10.21.월)
        //하지만 다음 수업에서는 심화로 array list를 이야기할것
    }

    private float timer = 0.0f;


	// Use this for initialization
	void Start () {
        buidBars();


    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3.0f)
        {
            buidBars();
            timer = 0.0f;
        }
	}
}
