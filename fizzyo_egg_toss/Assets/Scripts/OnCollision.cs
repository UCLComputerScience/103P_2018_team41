using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    //private float diff = 0;
    private Transform mCamera;
    private Transform collideObject;
    public static Transform lastCollidedPlatform;
    private Vector2 pointOfContact;
    private float smoothSpeed = .05f;
    private bool enterTop = false;
    private bool genPlatform = false;


    // Use this for initialization
    void Start()
    {
        mCamera = GameObject.FindWithTag("MainCamera").transform;
        //LevelGenerator.LevelGenerate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (genPlatform)
        {
            LevelGenerator.LevelGenerate();
            genPlatform = false;
        }
        if (collideObject != null)
        {
            float newPosY = 4f + collideObject.position.y;

            if ((newPosY - mCamera.position.y) > 0.0001)
            {
                Vector3 newPos = new Vector3(mCamera.position.x, newPosY, mCamera.position.z);
                mCamera.position = Vector3.Lerp(mCamera.position, newPos, smoothSpeed);
                //Debug.Log("Change!");
            } else
            {
                //Debug.Log("Done!");
                collideObject = null;
                
            }
            if ((newPosY - mCamera.position.y) < 0.5)
            {
                GameObject.FindWithTag("Player").GetComponent<EggControl>().enabled = true;
            }
         
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { //If the tag of the collider we touched is "enemy", then...

            pointOfContact = collision.contacts[0].normal; //Grab the normal of the contact point we touched

            //Debug.Log(collision.gameObject.transform.position.y);
            //if (diff == 0)
            //{
            //    diff = mCamera.position.y - collision.gameObject.transform.position.y;
            //}

            if (pointOfContact == new Vector2(0, -1))
            {
                if (lastCollidedPlatform != transform && lastCollidedPlatform != null)
                {
                    ScoreControl.currentScore += 1;
                }
                lastCollidedPlatform = transform;
                enterTop = true;

                if (transform.position.y > mCamera.position.y)
                {   
                    collideObject = transform;
                    //GameObject.Find("other_object_name").GetComponent(B).enabled = false;
                    GameObject.FindWithTag("Player").GetComponent<EggControl>().enabled = false;
                    genPlatform = true;

                    //Debug.Log(collideObject.position.y);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (enterTop)
        {
            transform.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            
        }
    }
}
