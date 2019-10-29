using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverSence;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text comboText;
    [SerializeField]
    private Text levelText;
    static public bool gameOver =false;
    [SerializeField]
    private Text lastScoreText;

    // Use this for initialization
    void Start ()
    {
        gameOverSence = GameObject.Find("GameOverBackround");
        gameOverSence.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        int score = Score.GetScore();
        int combo = Score.GetCombo();
        int level = GameManager.getLevel();



        comboText.text = combo.ToString();
        scoreText.text = score.ToString();
        levelText.text = level.ToString();
        if (gameOver)
        {
            gameOverSence.SetActive(true);
            lastScoreText.text = score.ToString();
        }
    }
}
