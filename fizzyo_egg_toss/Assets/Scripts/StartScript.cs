using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class StartScript : MonoBehaviour {
    
	public void changeScene()
    {
        EditorSceneManager.LoadScene("Game");
    }
}
