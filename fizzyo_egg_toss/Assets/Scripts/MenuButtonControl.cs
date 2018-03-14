using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuButtonControl : MonoBehaviour {

    private bool gamePaused = false;

    private void resetState()
    {
        GameOverMenu.gameIsOver = false;
        LevelGenerator.spawnPosY = -3.8f;
        ScoreControl.currentScore = 0;
        Time.timeScale = 1f;
    }

	public void restartGame()
    {
        resetState();
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
    }

    public void backToMainMenu()
    {
        resetState();
        EditorSceneManager.LoadScene("MainMenu");
    }

    public void pauseGame()
    {
        if (!gamePaused)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }

        GameObject.FindWithTag("Player").GetComponent<EggControl>().enabled = gamePaused;
        gamePaused = !gamePaused;
    }
}
