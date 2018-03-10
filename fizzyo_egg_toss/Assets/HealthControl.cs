using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[UnityEditor.InitializeOnLoad]
public class HealthControl : MonoBehaviour {

    //private static Transform HUD;
    //private static GameObject[] lifeSpriteArr;
    //private static Vector3 lifePos;
    //private static GameObject lifeSprite;

    private Transform HUD;
    private Vector3 lifePos;
    public GameObject lifeSprite;
    public static int lives;
    private static GameObject[] lifeSpriteArr;

    void Start()
    {
        //lives = l;
        HUD = GameObject.Find("HUD").transform;
        //lifeSprite = GameObject.Find("Life");
        lifeSpriteArr = new GameObject[lives];
        lifePos = new Vector3(8.75f, 4.7f);

        for (int i = 0; i < lives; i++)
        {
            lifeSpriteArr[i] = Instantiate(lifeSprite, lifePos, Quaternion.identity);
            lifeSpriteArr[i].transform.parent = HUD;
            lifePos.x -= 0.55f;
        }
    }

    //public static void GenerateLifeSprites()
    //{
    //    HUD = GameObject.Find("HUD").transform;
    //    lifeSprite = GameObject.Find("Life");
    //    int lives = EggHealth.lives;
    //    lifeSpriteArr = new GameObject[lives];
    //    lifePos = new Vector3(8.75f, 4.7f);

    //    for (int i = 0; i < lives; i++)
    //    {
    //        lifeSpriteArr[i] = Instantiate(lifeSprite, lifePos, Quaternion.identity);
    //        lifeSpriteArr[i].transform.parent = HUD;
    //        lifePos.x -= 0.55f;
    //    }
    //    Destroy(lifeSprite);
    //}

    public static void deductLife()
    {
        lives--;
        lifeSpriteArr[lives].SetActive(false);
    }
}
