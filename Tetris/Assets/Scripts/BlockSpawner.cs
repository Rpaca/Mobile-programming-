using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject[] blockPrefabs;
    private GameManager GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
       // if (GM.isSpawning == false)
            spawn();		
	}

    private void spawn()
    {
        GameObject tempt;
        Vector3 pos = this.gameObject.transform.position;
        int i = Random.Range(0, blockPrefabs.Length);
        tempt = Instantiate(blockPrefabs[i], pos, Quaternion.identity);
        GM.isSpawning = true;
    }
}
