using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    // VARIABLES
    public float initialSpeed = 7f;
    float xCoord;
    private Rigidbody2D rBody;

    public int lives = 3;

    private float speed;

    Collider2D coll = new Collider2D();


    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
     
        ////////////////////////////////
        /// Ship's Movement
        float horiz = Input.GetAxis("Horizontal");      

        xCoord = rBody.position.x;

        speed = initialSpeed;         

        // Checking Out Of Bounds
        if (xCoord < - 8) 
        {            
            if (horiz > 0)
            {               
                speed = initialSpeed;               
            }else
            {
                speed = 0;
            }        
        };

        if (xCoord > 8)
        {
            if (horiz < 0)
            {
                speed = initialSpeed;              
            }
            else
            {
                speed = 0;
            }
        };        
            
            rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        ////////////////////////////////
        /// END OF Ship's Movement
        /// 
              

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            //Debug.Log("HIT");
            if (lives <= 0)
            {
                Die();
            }else
            {
                lives -= 1;
                Debug.Log("HIT");
                Application.LoadLevel("Level1");
               // Application.LoadLevel("Start");
            }
            
        }

        if (other.tag == "EndOfLevel1")
        {
            Application.LoadLevel("Level1_Post_Title");
        }

    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
