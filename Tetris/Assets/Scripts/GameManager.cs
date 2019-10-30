using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject gameOverSence; // 게임 종료시 나오는 화면
    private UIManager UI;

    void Awake()
    {
        UI = GameObject.Find("GameManager").GetComponent<UIManager>();
        gameOverSence = GameObject.Find("GameOverBackround");
        gameOverSence.SetActive(false);
    }

    public void GameOver()
    {
        gameOverSence.SetActive(true);
        UI.UpdateLastScore();
    }


}
