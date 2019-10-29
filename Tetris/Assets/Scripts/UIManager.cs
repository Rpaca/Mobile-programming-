using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text comboText;
    [SerializeField]
    private Text levelText;



    // Use this for initialization
    void Start () {
		
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
    }
}
