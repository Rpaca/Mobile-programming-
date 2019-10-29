using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    static private int score = 0;
    static private int point = 10;
    static private int combo = 0;

    static public int GetScore()
    {
        return score;
    }

    static public int GetCombo()
    {
        return combo;
    }

    static public void addScore()
    {
        float bonus = point * combo * 0.5f;
        score += point + (int)bonus;
    }

    static public void addCombo()
    {
        combo++;
    }

    static public void resetCombo()
    {
        combo = 0;
    }


}
