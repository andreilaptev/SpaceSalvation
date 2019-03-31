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


    public static int score;
    public int extraLiveBonus = 0;

    public Text scoreText;
    public Text livesText;
    public Text healthText;

    public GameObject InfoPanel;
    public Text panelText;

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
    private float boost = 1f;
    private float verticalDirection; // doesn't allow to fly back
    private int rotateLeft; // used to rotate ship to the left over z-axis
    private int rotateRight;

    private float clockwise = 1000.0f;
    private float counterClockwise = -5.0f;

    private int nuclearWeapons;

    private float message1Time = 3.5f;
    private float message2Time = 6.0f;
    private float waitTime1 = 8.0f;
    private float timer = 0.0f;

    private string message1 = "Use MOUSE to navigate around the scene, SPACE to shoot and B to boost!";
    private string message2 = "Collect NUCLEAR drops and hit V to shoot the BOSS";
    private string message3 = "Pick HEALTH KIT to get bonus 10% of Health";

    private int lives = LevelsLivesCounter.currentLivesNumber;

    // used to rotate ship to the right over z-axis


    private GameObject starTrigger;
    private GameObject healthTrigger;

    private int currentSessionLives;

    Collider2D coll = new Collider2D();
    private object CircleCollider2D;



    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody>();
        //score = LevelsLivesCounter.currentGameScore;

        score = Level2ShipController.score;

        lives = LevelsLivesCounter.currentLivesNumber;

        if (lives == 0)
            Die();

        //currentSessionLives = lives;
        rotateLeft = 0;
        rotateRight = 360;

        nuclearWeapons = 0;

        speed = initialSpeed;

        // health = 100;

        //if (lives < 1) Die();

        ShowScore();
        ShowLives();

        ShowInfo(message1);

        atCursor = false;
       

        //Debug.Log(LevelsLivesCounter.currentLivesNumber);


    }

    void Update()
    {
        ShowHealth();

        timer += Time.deltaTime;
       // Debug.Log(timer);
        if (timer > message1Time)
        {
            //print("second");
            //InfoPanel.SetActive(false);
            ShowInfo(message2);
        }
        //else if (timer > message2Time && timer < waitTime1)
        //{
        //    ShowInfo(message2);
        //}
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
        float horiz = Input.GetAxis("Horizontal");

        float vert = Input.GetAxis("Vertical");

        xCoord = transform.position.x;

       // Debug.Log(xCoord);

       

        faceMouse();        

        if (!atCursor)
        transform.Translate(0, speed * Time.deltaTime * boost, 0); // Temporarely


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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // shooting with Spacebar or LeftClick button
        {
            //Debug.Log("shoot");
            ShootLeft();
            SoundManagerScript.PlaySound("fire");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1)) // shooting with LeftShift or RightClick button       
        {           
            if (nuclearWeapons > 0)
            {
                CastBomb();
                nuclearWeapons -= 1;

                SoundManagerScript.PlaySound("explosion");
            }
                
           
        }

        // Speed boost
        if (Input.GetKey(KeyCode.B))
            //print("pressed");
            boost = 2f;
        else
            // print("released");
            boost = 1f;

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
                health -= 20;

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
                if (lives < 1) 
                   Die();
                else
                {           
                   LevelsLivesCounter.currentLivesNumber -= 1;

                    SceneManager.LoadScene("Level3");

                }

            }
            else
            {
                health -= 20;

               // Debug.Log(health);
            }
        }

        // Hitting a Star - attain 100 points
        if (other.tag == "Star")
        {
            //Debug.Log("star");

            SoundManagerScript.PlaySound("collectCoin");

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

            SoundManagerScript.PlaySound("powerUp");
        }
        
    }

    void OnTriggerEnter (Collider other)
    {
       
            //Debug.Log("Entered");
        
    }


    private void ShowHealth()
    {
        healthText.text = "Health : " + health.ToString();
    }

    private void Die()
    {
        Destroy(this.gameObject);

        LevelsLivesCounter.currentLivesNumber = 3;
        LevelsLivesCounter.currentGameScore = 0;

        SceneManager.LoadScene("Die_Level3");
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
       // Debug.Log("Score " + scoreText.text);
    }

    void ShowLives()
    {
        //livesText.text = "Lives : " + currentSessionLives.ToString();
        livesText.text = "Lives : " + LevelsLivesCounter.currentLivesNumber.ToString();
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

    private void ShowInfo(string message)
    {
        panelText.text = message;
        if (timer > waitTime1)
            InfoPanel.SetActive(false);
    }
}
