using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    private static GameObject platformPrefab;
    private static int numberOfPlatforms = 2;
    private static int current_platform = 0;
    public static GameObject[] Platforms = new GameObject[4];//Keep twice the number of platforms
    private static float levelWidth = 4;
    public static float minY;
    public static float maxY;
    public static float spawnPosY = -3.8f;
    
    public static void LevelGenerate()
    {
        platformPrefab = GameObject.FindWithTag("Ground");

        platformPrefab.GetComponent<EdgeCollider2D>().enabled = true;
        //platformPrefab.transform.position = new Vector2(-20f, platformPrefab.transform.position.y);


        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (((current_platform == 3)&&(Platforms[0] != null))||(Platforms[current_platform] != null)){
                if ((current_platform == 3))
                 {  
                    //TOODO delete premades
                    Destroy(Platforms[0]);
                    Destroy(Platforms[1]);
                }
                else if ((current_platform == 1)&& (Platforms[3] != null))
                {
                        Destroy(Platforms[2]);
                        Destroy(Platforms[3]);
                }
                current_platform += 1;
                if (current_platform > 3)
                {
                    current_platform = 0;
                }
            }

            spawnPosY += 3.2f;
            Vector3 spawnPosition = new Vector3 { y = spawnPosY };
            //spawnPosition.y += 3.2F;
            //spawnPosition.x = -0.5F;
            //Debug.Log(spawnPosition);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Platforms[current_platform] =  Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
        if (Platforms[0] != null && Platforms[2] != null) { 
            platformPrefab.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
}
