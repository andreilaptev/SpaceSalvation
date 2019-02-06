using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Web;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    // VARIABLES
    public float initialSpeed = 7f;
    float xCoord;
    private Rigidbody2D rBody;
    public static int levelScore;

    public int score;
    public int lives;

    public Text scoreText;
    public Text livesText;

    private float speed;

    private GameObject starTrigger;

    Collider2D coll = new Collider2D();


    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        score = 0;
        ShowScore();
        


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
        // Hitting an Asteroid - death
        if (other.tag == "Asteroid")
        {
            //Debug.Log("HIT");
            if (lives <= 0)
            {
                Die();
            }else
            {
                lives -= 1;
                //Debug.Log("HIT");
                Application.LoadLevel("Level1");
               // Application.LoadLevel("Start");
            }
            
        }
        
        // Hitting End of level - redirects to next level
        if (other.tag == "EndOfLevel1")
        {
            score += 500;
            levelScore = score;
            Application.LoadLevel("Level1_Post_Title");

        }

        // Hitting a Star - ading 100 points
        if (other.tag == "Star")
        {
            score += 100;
            ShowScore();
            starTrigger = other.gameObject;

           // Debug.Log(starTrigger);

            starTrigger.GetComponent<StarController>().shown = false; 
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
        Debug.Log(scoreText.text);
    }
}
