using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text levelText; // 레벨
    [SerializeField]
    private Text scoreText; // 게임 중 점수
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text blockText;
    [SerializeField]
    private Text lastScore;

    private ScoreManager score;

    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        scoreText.text = score.GetScore().ToString();
        levelText.text = score.GetLevel().ToString();
        blockText.text = score.GetBlocks().ToString();
        timerText.text = score.GetTimer().ToString("N1");
        lastScore.text = score.GetScore().ToString(); ;
    }
}
