using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {
    
    public static int currentScore;
    public Text scoreText;

    void Update()
    {
        scoreText.text = ScoreControl.currentScore.ToString();
    }
}
