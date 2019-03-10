using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    public int score;
    public int lives;
    public int extraLiveBonus = 0;

    public Text scoreText;
    public Text livesText;

    // Shooting variables
    public GameObject laserSpawnpointLeft;
   // public GameObject laserSpawnpointRight;
    public float waitTime;
    public GameObject beam;

    public GameObject bullet;
    public Rigidbody2D bullet1;

    public float bulletSpeed;

   

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
        rigidBody = GetComponent<Rigidbody>();
        score = 0;
        lives = LevelsLivesCounter.currentLivesNumber;
        rotateLeft = 0;
        rotateRight = 360;

        if (lives < 1) Die();

        ShowScore();
        ShowLives();

        //Debug.Log(LevelsLivesCounter.currentLivesNumber);
    }

    void Update()
    {

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

       transform.Translate(0, speed * Time.deltaTime, 0); // Temporarely


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
        if (Input.GetKeyDown(KeyCode.Space)) // shooting with space button
        //if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("shoot");
            ShootLeft();
        }

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (health <= 0)
        {
           Die();     

        }
        else
        {
            health -= 10;

           // Debug.Log(health);
        }

        //Debug.Log(health);

        if (other.gameObject.tag == "Star")
        {

            score += 100;
            starTrigger = other.gameObject;
            starTrigger.GetComponent<StarController>().shown = false;
        }
            

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
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
            Debug.Log("star");

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

        SceneManager.LoadScene("Die");
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
}
