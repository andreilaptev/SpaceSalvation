﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Level2ShipController : MonoBehaviour
{
    // VARIABLES
    public float initialSpeed = 2f;
    float xCoord;
    //private Rigidbody2D rBody;
    private Rigidbody rigidBody;
    public static int levelScore;
    public static int totalLives;

    public int rotationAngle;

    public int health = 100;


    public static int score;
    public int extraLiveBonus = 0;

    
    public GameObject InfoPanel;
    public Text panelText;

    public Text scoreText;
    public Text livesText;
    public Text healthText;

    // Shooting variables
    public GameObject laserSpawnpointLeft;
   // public GameObject laserSpawnpointRight;
    public float waitTime;
    public GameObject beam;

    public GameObject bullet;
    public Rigidbody2D bullet1;

    public float bulletSpeed;
    public bool atCursor;    
   

    private float speed;
    private float boost = 1f;
    private float verticalDirection; // doesn't allow to fly back
    private int rotateLeft; // used to rotate ship to the left over z-axis
    private int rotateRight;

    private float clockwise = 1000.0f;
    private float counterClockwise = -5.0f;

    private float message1Time = 3.5f;
    private float message2Time = 6.0f;
    private float waitTime1 = 8.0f;
    private float timer = 0.0f;

    private string message1 = "Use MOUSE to navigate around the scene, SPACE to shoot and LEFT SHIFT to boost!";
    private string message2 = "Collect 10 COINS to get bonus life";
    private string message3 = "Pick HEALTH KIT to get bonus 10% of Health";


    // used to rotate ship to the right over z-axis


    private GameObject starTrigger;
    private GameObject healthTrigger;

    private int lives = LevelsLivesCounter.currentLivesNumber;

    // private int currentSessionLives = 3;

    Collider2D coll = new Collider2D();

    [Header("Audio")]
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody>();
        //score = LevelsLivesCounter.currentGameScore;

        score = Level1ShipController.score;


        Debug.Log("score " + score);       

        rotateLeft = 0;
        rotateRight = 360;

       // health = 100;

        if (lives < 1) Die();

        ShowScore();
        ShowLives();
        ShowHealth();

        ShowInfo(message1);

        atCursor = false;

        //Debug.Log(LevelsLivesCounter.currentLivesNumber);
    }

 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Pause or unpause
        {
            // Set my audio snapshot to the pause or unpause snapshot
            // Pause my game.
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;

            if (Time.timeScale == 0) // Paused
            {
                paused.TransitionTo(0.01f);
            }
            else // Unpaused
            {
                unpaused.TransitionTo(0.01f);
            }
        }

        ShowHealth();

        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > message1Time && timer < message2Time)
        {
            ShowInfo(message2);
        }
        else if (timer > message2Time && timer < waitTime1)
        {
            ShowInfo(message3);
        }
        else if (timer > waitTime1)
        {
            InfoPanel.SetActive(false);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {     


        ////////////////////////////////
        ///// Ship's Movement
        //float horiz = Input.GetAxis("Horizontal");

        //float vert = Input.GetAxis("Vertical");           

        //xCoord = rigidBody.position.x;

        speed = initialSpeed;

        faceMouse();

        if (!atCursor)
       transform.Translate(0, speed * Time.deltaTime * boost, 0); // Temporarily


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


        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Debug.Log("Up");
        //    rigidBody.velocity = transform.forward * speed;
        //    //transform.Translate(Vector3.forward * speed*Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow)) // Listens to my space bar key being pressed
        //{
        //    RotateLeftPermanent();

        //}
        // else if (Input.GetKey(KeyCode.RightArrow)) // Listens to my space bar key being pressed
        //{
        //    RotateRightPermanent();
        // }
        //    /// END OF Ship's rotation
        /// 

        

        //Shooting

        //if (Input.GetMouseButtonDown(0)) // shooting with left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // shooting with Spacebar or LeftClick button
        {
            //Debug.Log("shoot");
            ShootLeft();
            SoundManagerScript.PlaySound("fire");
        }

        // Speed boost
        if (Input.GetKey(KeyCode.LeftShift)) // use boost with LeftShift button
        {
            //print("pressed");
            boost = 2f;
            SoundManagerScript.PlaySound("boost");
        }
        //print("released");
        boost = 1f;

    }



    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    //Debug.Log(health);

    //    //if (other.gameObject.tag == "EnemyBullet")
    //    //{
    //    //    if (health <= 0)
    //    //    {
    //    //        if (lives <=0 )
    //    //             Die();
    //    //        else
    //    //        {
    //    //           //lives -= 1;

    //    //            SceneManager.LoadScene("Level2");

    //    //        }

    //    //    }
    //    //    else
    //    //    {
    //    //        health -= 3;

    //    //        Debug.Log(health);
    //    //    }
    //    //}
       

    //    //Debug.Log(health);

    //    if (other.gameObject.tag == "Star")
    //    {

    //        score += 100;
    //        starTrigger = other.gameObject;
    //        starTrigger.GetComponent<StarController>().shown = false;
    //    }

    //    //if (other.gameObject.tag == "Health")
    //    //{
    //    //    health += 10;

    //    //    healthTrigger = other.gameObject;
    //    //    healthTrigger.GetComponent<Health>().shown = false;

    //    //    Debug.Log(health);

    //    //}

    //}

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "EnemyBullet")
        {
            if (health <= 0)
            {
                if (lives <= 0)
                {
                    Die();
                }
                   
                else
                {

                    //lives -= 1;

                    LevelsLivesCounter.currentLivesNumber  -= 1;

                    //Debug.Log("lives" + lives);

                    SceneManager.LoadScene("Level2");

                }

            }
            else
            {
                health -= 20;

                //Debug.Log(health);
            }
        }

        if (other.tag == "Health")
        {
            health += 10;
            Destroy(other.gameObject);

            SoundManagerScript.PlaySound("collectHealth");

            ShowHealth();

            Debug.Log( "Added " + health);
        }






        // Hitting a Star - attain 100 points
        if (other.tag == "Star")
        {
            //Debug.Log("star");

            Destroy(other.gameObject);

            SoundManagerScript.PlaySound("collectCoin");

            score += 100;
            extraLiveBonus += 100;
            //Debug.Log("Score " + score);

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

    private void ShowHealth()
    {
        healthText.text = "Health : " + health.ToString();
    }

    private void Die()
    {
        Destroy(this.gameObject);

        LevelsLivesCounter.currentLivesNumber = 0;
        LevelsLivesCounter.currentGameScore = 0;
        LevelsLivesCounter.currentLivesNumberLevel2 = 0;

        SceneManager.LoadScene("Die_Level2");
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
        //Debug.Log("Score " +  scoreText.text);
    }

    void ShowLives()
    {
        livesText.text = "Lives : " + lives.ToString();
    }

    //void RotateRight(float horiz)
    //{
    //    var rot = 40 * horiz;

    //    transform.rotation = Quaternion.Euler(0, 0, -rot);
    //}


    //private void RotateLeftPermanent()
    //{
    //    Debug.Log(transform.rotation.x);
    //    //rotateLeft = rotateLeft + rotationAngle;
    //    //transform.rotation = Quaternion.Euler(0, 0, rotateLeft);
    //    transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 200, Space.World);
    //}

    //private void RotateRightPermanent()
    //{
    //    Debug.Log(transform.rotation.x);
    //    //rotateRight = rotateRight - rotationAngle;
    //    //transform.rotation = Quaternion.Euler(0, 0, rotateRight);
    //    transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 200, Space.World);
    //}

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;

        //Debug.Log(mousePosition.x);
        //Debug.Log(mousePosition.y);
    }

    void ShootLeft()
    {

        Rigidbody2D bulletInstance;


        //Instantiate(beam.transform, laserSpawnpointLeft.transform.position, Quaternion.identity);
        //Instantiate(beam.transform, laserSpawnpointRight.transform.position, Quaternion.identity);
        bulletInstance = Instantiate(bullet1, laserSpawnpointLeft.transform.position, Quaternion.identity) as Rigidbody2D;

        bulletInstance.AddForce(laserSpawnpointLeft.transform.up * bulletSpeed);

        //bulletInstance = Instantiate(bullet1, laserSpawnpointRight.transform.position, Quaternion.identity) as Rigidbody2D;

        //bulletInstance.AddForce(laserSpawnpointRight.transform.up * 500);

    }

    private void ShowInfo(string message)
    {
        panelText.text = message;
        //if (timer > waitTime)
        //    InfoPanel.SetActive(false);
    }

}
