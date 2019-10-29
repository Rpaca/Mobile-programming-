using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject[] blockPrefabs;
    private int nextShape = -1;
    GameObject nextBlocks;
    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        var GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        if (GM.isSpawning == false)
            spawn();		
	}

    private void spawn()
    {
        var GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        GameObject tempt;
        int i;
        Vector3 pos = this.gameObject.transform.position;
        if (nextShape == -1)
            i = Random.Range(0, blockPrefabs.Length);
        else
            i = nextShape;

        tempt = Instantiate(blockPrefabs[i], pos, Quaternion.identity);
        createNextBlock();
        GM.isSpawning = true;
    }

    private void createNextBlock()
    {
        Destroy(nextBlocks);
        Vector3 pos = new Vector3(20.0f, 14.5f, -1.0f);
        nextShape = Random.Range(0, blockPrefabs.Length);
        nextBlocks = Instantiate(blockPrefabs[nextShape], pos, Quaternion.identity);
        nextBlocks.GetComponent<Blocks>().enabled = false;
    }
}
