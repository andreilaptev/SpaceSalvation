﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2ShipController : MonoBehaviour
{
    // VARIABLES
    public float initialSpeed = 7f;
    float xCoord;
    //private Rigidbody2D rBody;
    private Rigidbody2D rigidBody;
    public static int levelScore;
    public static int totalLives;

    public int rotationAngle;


    public int score;
    public int lives;
    public int extraLiveBonus = 0;

    public Text scoreText;
    public Text livesText;

    private float speed;
    private float verticalDirection; // doesn't allow to fly back
    private int rotateLeft; // used to rotate ship to the left over z-axis
    private int rotateRight;

    private float clockwise = 1000.0f;
    private float counterClockwise = -5.0f;


    // used to rotate ship to the right over z-axis


    private GameObject starTrigger;

    Collider2D coll = new Collider2D();


    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        lives = LevelsLivesCounter.currentLivesNumber;
        rotateLeft = 0;
        rotateRight = 360;

        if (lives < 1) Die();

        ShowScore();
        ShowLives();

        Debug.Log(LevelsLivesCounter.currentLivesNumber);

    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += Vector3.forward * Time.deltaTime *speed;
        //}        
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    //rigidBody.position  = rigidBody.position + (Vector3.left * Time.deltaTime * speed);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //   // rbody.position += Vector3.right * Time.deltaTime * speed;
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(0, Time.deltaTime * clockwise, 0);
        //}
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        //}
    
}


    // Update is called once per frame
    void FixedUpdate()
    {
      
        ////////////////////////////////
        /// Ship's Movement
        float horiz = Input.GetAxis("Horizontal");

        float vert = Input.GetAxis("Vertical");       
      

        if (horiz < 0) RotateLeft(horiz);
            else if (horiz > 0) RotateRight(horiz);
        // else RotateStraight();

        
        

        xCoord = rigidBody.position.x;

        //if (vert > 0) verticalDirection = vert * speed;
        //    else verticalDirection = rigidBody.velocity.y;

        speed = initialSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            rigidBody.velocity = transform.forward * speed; ;
        }

        // Checking Off Bounds
        //if (xCoord < -8)
        //{
        //    if (horiz > 0)
        //    {
        //        speed = initialSpeed;

        //        RotateRight(horiz);

        //    }
        //    else
        //    {
        //        speed = 0;

        //        RotateStraight();
        //    }
        //};

        //if (xCoord > 8)
        //{
        //    if (horiz < 0)
        //    {
        //        speed = initialSpeed;

        //        RotateLeft(horiz);
        //    }
        //    else
        //    {
        //        speed = 0;

        //        RotateStraight();
        //    }
        //};



        //rBody.velocity = new Vector2(horiz * speed, verticalDirection); //


        ////////////////////////////////
        /// END OF Ship's Movement
        /// 

        /// Ship's rotation
        /// 


        if (Input.GetKey(KeyCode.Z)) // Listens to my space bar key being pressed
        {       
            RotateLeftPermanent();

        }
        if (Input.GetKey(KeyCode.X)) // Listens to my space bar key being pressed
        {
            RotateRightPermanent();
           

        }
        /// END OF Ship's rotation
        /// 

    }

  

    void OnTriggerEnter2D(Collider2D other)
    {
        // Hitting an Asteroid - death
        if (other.tag == "Asteroid")
        {
            //Debug.Log("HIT");
            if (lives < 1)
            {
                Die();
            }
            else
            {
                LevelsLivesCounter.currentLivesNumber -= 1;

                Application.LoadLevel("Level1");

            }

        }

        // Hitting End of level - redirects to next level
        if (other.tag == "EndOfLevel1")
        {
            score += 200;

            extraLiveBonus += 200;

            if (extraLiveBonus >= 1000)
            {
                lives += 1;
                extraLiveBonus = 0;
                ShowScore();
            }

            levelScore = score;

            LevelsLivesCounter.currentLivesNumber = lives;

            Application.LoadLevel("Level1_Post_Title");

        }

        // Hitting a Star - ading 100 points
        if (other.tag == "Star")
        {
            score += 100;
            extraLiveBonus += 100;

            if (extraLiveBonus >= 1000)
            {
                lives += 1;
                extraLiveBonus = 0;
                ShowLives();
            }


            ShowScore();
            starTrigger = other.gameObject;

            // Debug.Log(starTrigger);

            starTrigger.GetComponent<StarController>().shown = false;
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);

        LevelsLivesCounter.currentLivesNumber = 3;

        Application.LoadLevel("Die");
    }

    void ShowScore()
    {
        //scoreText.text = "Score : " + score.ToString();
        //Debug.Log(scoreText.text);
    }

    void ShowLives()
    {
       // livesText.text = "Lives : " + lives.ToString();
    }

    void RotateRight(float horiz)
    {
        var rot = 40 * horiz;

        transform.rotation = Quaternion.Euler(0, 0, -rot);
    }

    void RotateLeft(float horiz)
    {
        var rot = 40 * horiz;

        transform.rotation = Quaternion.Euler(0, 0, -rot);
    }

    void RotateStraight()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void RotateLeftPermanent()
    {
        Debug.Log(transform.rotation.x);
        //rotateLeft = rotateLeft + rotationAngle;
        //transform.rotation = Quaternion.Euler(0, 0, rotateLeft);
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 200, Space.World);
    }

    private void RotateRightPermanent()
    {
        Debug.Log(transform.rotation.x);
        //rotateRight = rotateRight - rotationAngle;
        //transform.rotation = Quaternion.Euler(0, 0, rotateRight);
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 200, Space.World);
    }
}
