using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1ShipController : MonoBehaviour
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
    private float verticalDirection; // doesn't allow to fly back
    private int rotateLeft; // used to rotate ship to the left over z-axis
    private int rotateRight;

    private float clockwise = 1000.0f;
    private float counterClockwise = -5.0f;

    private float message1Time = 2.0f;
    private float message2Time = 4.0f;
    private float waitTime1 = 7.0f;
    private float timer = 0.0f;

    private string message1 = "Use MOUSE to navigate around the scene and SPACE to shoot!";
    private string message2 = "Collect 10 COINS to get bonus life";
    private string message3 = "Pick HEALTH KIT to get bonus 10% of Health";


    // used to rotate ship to the right over z-axis


    private GameObject starTrigger;
    private GameObject healthTrigger;

    private int lives = LevelsLivesCounter.currentLivesNumber;

    // private int currentSessionLives = 3;

    Collider2D coll = new Collider2D();


    // METHODS
    // Start is called before the first frame update
    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody>();
        score = LevelsLivesCounter.currentGameScore;


        Debug.Log("Lives" + lives);

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



        speed = initialSpeed;

        faceMouse();

        if (!atCursor)
            transform.Translate(0, speed * Time.deltaTime, 0); // Temporarely



        //Shooting

        //if (Input.GetMouseButtonDown(0)) // shooting with left mouse button
        if (Input.GetKeyDown(KeyCode.Space)) // shooting with space button
        //if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("shoot");
            ShootLeft();
        }

    }




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

                    LevelsLivesCounter.currentLivesNumber -= 1;

                    //Debug.Log("lives" + lives);

                    SceneManager.LoadScene("Level2");

                }

            }
            else
            {
                health -= 3;

                //Debug.Log(health);
            }
        }

        if (other.tag == "Health")
        {
            health += 10;
            Destroy(other.gameObject);

            ShowHealth();

            Debug.Log("Added " + health);
        }


        // Hitting a Star - ading 100 points
        if (other.tag == "Star")
        {
            //Debug.Log("star");

            Destroy(other.gameObject);

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
