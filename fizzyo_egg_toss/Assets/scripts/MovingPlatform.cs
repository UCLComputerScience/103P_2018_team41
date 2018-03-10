using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    //public GameObject Platform;
    private float moveSpeed = 2f;
    public float positiveMoveSpeed;
    public float negativeMoveSpeed;
    //public Transform currentPoint;
    //public Transform[] points;
    //public int pointSelection;

    // Use this for initialization
    void Start () {
        //currentPoint = points[pointSelection];
        negativeMoveSpeed = -moveSpeed;
        positiveMoveSpeed = moveSpeed;

        if (Random.Range(0, 2) == 0)
        {
            moveSpeed = negativeMoveSpeed;
        } else
        {
            moveSpeed = positiveMoveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if (Platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];

        }

    }*/
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(10F, transform.position.y, transform.position.z), Time.deltaTime * moveSpeed);
        if (transform.position.x >= 4) {
            moveSpeed = negativeMoveSpeed;
        } else if (transform.position.x <= -4)
        {
            moveSpeed = positiveMoveSpeed;
        }
        //moveSpeed
    }
}
