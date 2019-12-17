using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int level = 1;
    private int point = 50;
    private int numOfBlocks = 5;
    private float timer = 100;

    [SerializeField]
    private GameObject gameOverSence;

    public void AddScore()
    {
        score += point;
    }
    public void CountBlocks()
    {
        numOfBlocks--;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetBlocks()
    {
        return numOfBlocks;
    }

    public float GetTimer()
    {
        return timer;
    }

    void Start()
    {
        gameOverSence.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        CheckLevel();
        CheckGameOver();
    }

    private void CheckLevel()
    {
        if (level != (int)score / 500 + 1)
        {
            level = (int)score / 500 + 1;
            timer += 100;
            numOfBlocks += 10;
        }
    }

    private void CheckGameOver()
    {
        if (timer <= 0 || !GameObject.Find("Player"))
        {
            gameOverSence.SetActive(true);
        }
    }
}
