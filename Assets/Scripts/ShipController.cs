using System;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
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

    public GameObject levelInfoPanel;
    public Text infoText;

    public GameObject death;

    public Text scoreText;
    public Text livesText;

    private float speed;
    private float messageTime = 3.0f;
    private float waitTime = 7.0f;
    private float timer = 0.0f;

    private GameObject starTrigger;

    private string message1 = "Avoid collisions with asteroids!";
    private string message2 = "And collect COINS to get bonus life for each 10";

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

        ShowInfo(message1);
       // Debug.Log(LevelsLivesCounter.currentLivesNumber);

    }

 
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > messageTime)
        {
            ShowInfo(message2);
        }
        else if (timer > waitTime)
        {
            levelInfoPanel.SetActive(false);
        }

        

        ////////////////////////////////
        /// Ship's Movement
        float horiz = Input.GetAxis("Horizontal");

        if (horiz < 0) RotateLeft(horiz);
           else if (horiz > 0) RotateRight(horiz);
             else RotateStraight();


            xCoord = rBody.position.x;

        speed = initialSpeed;         

        // Checking Off Bounds
        if (xCoord < - 8) 
        {            
            if (horiz > 0)
            {               
                speed = initialSpeed;

                RotateRight(horiz);

            }else
            {
                speed = 0;

                RotateStraight();
            }        
        };

        if (xCoord > 8)
        {
            if (horiz < 0)
            {
                speed = initialSpeed;

                RotateLeft(horiz);
            }
            else
            {
                speed = 0;

                RotateStraight();
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
            if (lives < 1)
            {
                //Instantiate(death, transform.position, Quaternion.identity);
                Die();
            }else
            {
                //Instantiate(death, transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);

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
            LevelsLivesCounter.currentGameScore = score;

            Application.LoadLevel("Level1_Post_Title");

        }

        // Hitting a Star - ading 100 points
        if (other.tag == "Star")
        {
            score += 50;
            extraLiveBonus += 50;

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
        LevelsLivesCounter.currentGameScore = 0;

        Application.LoadLevel("Die");
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
        Debug.Log(scoreText.text);
    }

     void ShowLives()
    {
        livesText.text = "Lives : " + lives.ToString();
    }

    private void ShowInfo(string message)
    {


        infoText.text = message;
        if (timer > waitTime)
            levelInfoPanel.SetActive(false);
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
