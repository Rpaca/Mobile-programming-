using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawner : MonoBehaviour {
    //좀비 생성 기능
    //좀비 삭제 기능
    //컴포넌트당 1개의 기능만 : 좀비의 총 갯수 관리


    static private int nZombies;
    //전체 좀비수를 관리하기 위해서 좀비 삭제작업을 zombieController에게 시키면 private 변수인 int를 접근불가
    //그렇다고 nZombies를 public으로 하는 코드는 좋지않
    private float timer = 0.0f;
    [SerializeField]
    private GameObject zombiePrefab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        { 
            spawn();
            Debug.Log("Spawn");
            timer = 0f;
        }

	}

    private void spawn()
    {
        if (nZombies > 4) return;

        Vector3 pos = new Vector3(Random.Range(-10f,10f), 0f, Random.Range(-10f, 10f));
        var zombie = Instantiate(zombiePrefab, pos, Quaternion.identity);
        nZombies++;
    }

    public void destroyMe(GameObject obj)
    {
        Destroy(obj);
        nZombies--;
    }
}

