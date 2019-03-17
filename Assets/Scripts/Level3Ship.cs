using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Level3Ship : MonoBehaviour
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
    public Rigidbody2D bomb;

    public float bulletSpeed;
    public float bombSpeed;
    public bool atCursor;



    private float speed;
    private float verticalDirection; // doesn't allow to fly back
    private int rotateLeft; // used to rotate ship to the left over z-axis
    private int rotateRight;

    private float clockwise = 1000.0f;
    private float counterClockwise = -5.0f;

    private int nuclearWeapons;
    


    // used to rotate ship to the right over z-axis


    private GameObject starTrigger;
    private GameObject healthTrigger;

    

    Collider2D coll = new Collider2D();
    private object CircleCollider2D;



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

        nuclearWeapons = 0;

        speed = initialSpeed;

        // health = 100;

        if (lives < 1) Die();

        ShowScore();
        ShowLives();

        atCursor = false;
       

        //Debug.Log(LevelsLivesCounter.currentLivesNumber);


    }

 
    // Update is called once per frame
    void FixedUpdate()
    {

        ////////////////////////////////
        ///// Ship's Movement
        float horiz = Input.GetAxis("Horizontal");

        float vert = Input.GetAxis("Vertical");

        xCoord = transform.position.x;

       // Debug.Log(xCoord);

       

        faceMouse();        

        if (!atCursor)
        transform.Translate(0, speed * Time.deltaTime, 0); // Temporarely


        // Checking Off Bounds
        //if (xCoord < -8)                 
        //    speed = 0;
        //    else        
        //        speed = initialSpeed;    

        //if (xCoord > 8)
        //      speed = 0;  
        //    else           
        //        speed = initialSpeed;



        //rBody.velocity = new Vector2(horiz * speed, verticalDirection); //


        ////////////////////////////////
        /// END OF Ship's Movement
        /// 


        //Shooting

        //if (Input.GetMouseButtonDown(0)) // shooting with left mouse button
        if (Input.GetKeyDown(KeyCode.Space)) // shooting with space button
        //if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("shoot");
            ShootLeft();
        }

        if (Input.GetKeyDown(KeyCode.V)) // shooting with V button        
        {           
            if (nuclearWeapons > 0)
            {
                CastBomb();
                nuclearWeapons -= 1;
            }
                
           
        }

    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(health);

        if (other.gameObject.tag == "EnemyBullet")
        {
            if (health <= 0)
            {
                //if (lives <=0 )
                //     Die();
                //else
                //{
                //    LevelsLivesCounter.currentLivesNumber -= 1;

                //    SceneManager.LoadScene("Level2");

                //}

            }
            else
            {
                health -= 1;

                //Debug.Log(health);
            }
        }


        //Debug.Log(health);

        if (other.gameObject.tag == "Star")
        {

            score += 100;
            starTrigger = other.gameObject;
            starTrigger.GetComponent<StarController>().shown = false;
        }

        if (other.gameObject.tag == "Nuclear")
        {

            nuclearWeapons += 1;
        }

        //if (other.gameObject.tag == "Health")
        //{
        //    health += 10;

        //    healthTrigger = other.gameObject;
        //    healthTrigger.GetComponent<Health>().shown = false;

        //    Debug.Log(health);

        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BossDropBullet")
        {
            health -= 10;

            Destroy(other.gameObject);
            Debug.Log("health" + health);
        }

        if (other.gameObject.tag == "EnemyBullet")
        {
            if (health <= 0)
            {
                if (lives <= 0)
                    Die();
                else
                {
                    LevelsLivesCounter.currentLivesNumber -= 1;

                    SceneManager.LoadScene("Level3");

                }

            }
            else
            {
                health -= 1;

                Debug.Log(health);
            }
        }

        // Hitting a Star - ading 100 points
        if (other.tag == "Star")
        {
            //Debug.Log("star");

            score += 100;
            extraLiveBonus += 100;
            Debug.Log("Score " + score);

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



        if (other.gameObject.tag == "Nuclear")
        {

            nuclearWeapons += 1;

            Destroy(other.gameObject);
        }
        
    }

    void OnTriggerEnter (Collider other)
    {
       
            Debug.Log("Entered");
        
    }

    private void Die()
    {
        Destroy(this.gameObject);

        LevelsLivesCounter.currentLivesNumber = 3;

        SceneManager.LoadScene("Die_Level3");
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
       // Debug.Log("Score " + scoreText.text);
    }

    void ShowLives()
    {
        livesText.text = "Lives : " + lives.ToString();
    }


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

        bulletInstance = Instantiate(bullet1, laserSpawnpointLeft.transform.position, Quaternion.identity) as Rigidbody2D;

        bulletInstance.AddForce(laserSpawnpointLeft.transform.up * bulletSpeed);

        //bulletInstance = Instantiate(bullet1, laserSpawnpointRight.transform.position, Quaternion.identity) as Rigidbody2D;

        //bulletInstance.AddForce(laserSpawnpointRight.transform.up * 500);

    }

    private void CastBomb()
    {
        Rigidbody2D bombInstance;

        bombInstance = Instantiate(bomb, laserSpawnpointLeft.transform.position, Quaternion.identity) as Rigidbody2D;

        bombInstance.AddForce(laserSpawnpointLeft.transform.up * bombSpeed);
    }
}
