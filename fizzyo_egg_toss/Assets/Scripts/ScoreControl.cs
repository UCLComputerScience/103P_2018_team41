using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreControl : MonoBehaviour {
    
    public static int currentScore;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI gameOverScoreText;
    
    void Update()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = ScoreControl.currentScore.ToString();

        if (GameOverMenu.gameIsOver && GameObject.Find("GameOverScoreText") != null)
        {
            gameOverScoreText = GameObject.Find("GameOverScoreText").GetComponent<TextMeshProUGUI>();
            gameOverScoreText.text = ScoreControl.currentScore.ToString();
        }
    }
    
}
