using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isSpawning = false;
    static public int level = 1;


    static public int getLevel()
    {
        return level;
    }

    private void stageLevelUP()
    {
        // Level.2
        if (Score.GetScore() > 50)
        {
           // Blocks.setBlockSpeed(0.9f);
            level = 2;
        }

        // Level.3
        if (Score.GetScore() > 100)
        {
            //Blocks.setBlockSpeed(0.9f);
            level = 3;
        }

        // Level.4
        if (Score.GetScore() > 150)
        {
            //Blocks.setBlockSpeed(0.9f);
            level = 4;
        }

        // Level.5
        if (Score.GetScore() > 200)
        {
            //Blocks.setBlockSpeed(0.9f);
            level = 5;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        stageLevelUP();

    }
}
