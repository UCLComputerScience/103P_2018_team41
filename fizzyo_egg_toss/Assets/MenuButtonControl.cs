using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuButtonControl : MonoBehaviour {

	public static void restartGame()
    {
        LevelGenerator.spawnPosY = -3.8f;
        ScoreControl.currentScore = 0;
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
    }
}
