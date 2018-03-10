using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggHealth : MonoBehaviour
{

    private Transform mCamera;
    public int lives;

    // Use this for initialization
    private void Awake()
    {
        mCamera = GameObject.FindWithTag("MainCamera").transform;
        HealthControl.lives = lives;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (mCamera.position.y - 15f)) // original was 6.4 but we want a longer delay
        {
            if (HealthControl.lives != 0)
            {
                HealthControl.deductLife();


                if (HealthControl.lives > 0)
                {
                    transform.position = new Vector3(OnCollision.lastCollidedPlatform.position.x, OnCollision.lastCollidedPlatform.position.y + 1.5f, OnCollision.lastCollidedPlatform.position.z);
                    OnCollision.lastCollidedPlatform.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (HealthControl.lives == 0 && (transform.position.y < (mCamera.position.y - 50f)))
        {
            //Time.timeScale = 0f; //Uncomment this if you want all to stop moving
            //transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //transform.GetComponent<Rigidbody2D>().isKinematic = true;
            //Debug.Log(transform);
            //Debug.Log(transform.GetComponent<Rigidbody2D>());
            GameOverMenu.gameIsOver = true;
        }
    }
}
