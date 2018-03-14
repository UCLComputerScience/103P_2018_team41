using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCloudGenerator : MonoBehaviour {

    public GameObject darkCloud;
    private Transform mCamera;
    private int currentTime;
    private int prevTime;

    void Start()
    {
        mCamera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (int)Time.timeSinceLevelLoad;
        if (!GameOverMenu.gameIsOver) { 
            if (prevTime != currentTime && currentTime % 3 == 0 && currentTime > 5)
            {
                prevTime = currentTime;
                for(int i = 0; i < 3; i++) { 
                    Instantiate(darkCloud, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(mCamera.position.y - 4f, mCamera.position.y + 4f), -1), Quaternion.identity).transform.parent = mCamera;
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                foreach (GameObject dc in GameObject.FindGameObjectsWithTag("DarkCloud"))
                {
                    Destroy(dc);
                }
            }
        }
    }
}
