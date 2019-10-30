using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int point = 10;
    private int combo = 0;
    private int level = 1;
    private int lastScore = 0;

    public int GetScore()
    {
        return score;
    }

    public int GetCombo()
    {
        return combo;
    }

    public int GetLevel()
    {
        return level;
    }

    public void AddScore()
    {
        float bonus = point * combo * 0.5f;
        score += point + (int)bonus;
    }

    public void AddCombo()
    {
        combo++;
    }

    public void ResetCombo()
    {
        combo = 0;
    }


    void Update()
    {
        CheckLevel();
    }

    public void CheckLevel()
    {
        level = (int)score / 50 + 1;
    }

}
