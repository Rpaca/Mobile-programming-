using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText; // 게임 중 점수
    [SerializeField]
    private Text comboText; // 콤보
    [SerializeField]
    private Text levelText; // 레벨
    [SerializeField]
    private Text lastScoreText;// 최종 점수

    private ScoreManager Score;

    void Start()
    {
        Score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    void Update ()
    {
        scoreText.text = Score.GetScore().ToString();
        comboText.text = Score.GetCombo().ToString();
        levelText.text = Score.GetLevel().ToString();
    }

    public void UpdateLastScore()
    {
        lastScoreText.text = Score.GetScore().ToString();
    }
}
