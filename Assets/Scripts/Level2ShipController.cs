using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2ShipController : MonoBehaviour
{
    // VARIABLES
    public float initialSpeed = 7f;
    float xCoord;
    private Rigidbody2D rBody;
    public static int levelScore;
    public static int totalLives;


    public int score;
    public int lives;
    public int extraLiveBonus = 0;

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
        lives = LevelsLivesCounter.currentLivesNumber;

        if (lives < 1) Die();

        ShowScore();
        ShowLives();

        Debug.Log(LevelsLivesCounter.currentLivesNumber);

    }

    void Update()
    {
      
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        ////////////////////////////////
        /// Ship's Movement
        float horiz = Input.GetAxis("Horizontal");

        float vert = Input.GetAxis("Vertical");
        
        Debug.Log(vert);

        //if (horiz < 0) RotateLeft(horiz);
        //else if (horiz > 0) RotateRight(horiz);
        //else RotateStraight();


        xCoord = rBody.position.x;

        speed = initialSpeed;

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

        rBody.velocity = new Vector2(horiz * speed, vert * speed); //rBody.velocity.y


        ////////////////////////////////
        /// END OF Ship's Movement
        /// 

        /// Ship's rotation
        /// 
        if (Input.GetKeyDown("space")) // Listens to my space bar key being pressed
        {

            Debug.Log("Left");
            //rBody.AddForce(new Vector2(0, jumpForce));
            RotateLeft(horiz);

        }
        if (Input.GetKeyDown(KeyCode.W)) // Listens to my space bar key being pressed
        {
            //rBody.AddForce(new Vector2(0, jumpForce));
            RotateRight(horiz);
            print("Right");

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
}
