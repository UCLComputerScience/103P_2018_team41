using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EggControl : MonoBehaviour {

    public float jumpForce = 500f;
    private bool jump = false;
    private bool grounded = false;
    //private Transform camera;
    private Rigidbody2D rb2d;
    private Vector2 pointOfContact;

    // Use this for initialization
    void Start()
    {
        LevelGenerator.LevelGenerate();
        rb2d = GetComponent<Rigidbody2D>();
        //camera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Grounded: " + grounded + " | Jump: " + jump);
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
            grounded = false;
            //grounded = false;

            //rb.AddForce(Vector2.up * jumpHeight);
            //    allowJump = false;
            //    Vector2 velocity = rb.velocity;
            //    velocity.y = jumpHeight;
            //    rb.velocity = velocity;
            //}
            //Debug.Log("test");
            //movement = Input.GetAxis("Vertical") * jumpHeight;
            //allowJump = false;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            //rb2d.AddForce(new Vector2(0f, jumpForce));
            Vector2 velocity = rb2d.velocity;
            velocity.y = jumpForce;
            rb2d.velocity = velocity;
            jump = false;
        }

    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        grounded = true;
    //    }
    //}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { //If the tag of the collider we touched is "enemy", then...


            pointOfContact = collision.contacts[0].normal; //Grab the normal of the contact point we touched

            //Detect which side of the collider we touched
            //if (pointOfContact == new Vector2(-1, 0))
            //{
            //    Debug.Log("We touched the left side of the enemy!");
            //}

            //if (pointOfContact == new Vector2(1, 0))
            //{
            //    Debug.Log("We touched the right side of the enemy!");
            //}

            //if (pointOfContact == new Vector2(0, -1))
            //{
            //    Debug.Log("We touched the enemy's bottom!");
            //}

            if (pointOfContact == new Vector2(0, 1))
            {
                grounded = true;
                transform.parent = collision.transform;
                //Debug.Log("We touched the top of the enemy!");
                //if (collision.gameObject.transform.position.y > camera.position.y)
                //{
                //    Debug.Log("Change!");
                //}
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;
        //if (collision.gameObject.tag == "Ground")
        //{
        //    pointOfContact = collision.contacts[0].normal;

        //    if (pointOfContact == new Vector2(0, 1))
        //    {
        
        //    }
        //}
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    isFalling = false;
    //    Debug.Log("test");
    //}
}
