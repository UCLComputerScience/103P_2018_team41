using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    public static bool gameIsOver = false;

    public GameObject gameOverMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (gameIsOver == true)
        {
            gameOverMenuUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape)) //restart game
            {
                gameIsOver = false;
                gameOverMenuUI.SetActive(false);
                MenuButtonControl.restartGame();
            }
        }
	}
}
