using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{

    // VARIABLES
    public float initialSpeed = 7f;
    float xCoord;
    private Rigidbody2D rBody;
    public static int levelScore;
    public static int totalLives;

    

    public int score;
    
    public int extraLiveBonus = 0;

    public GameObject levelInfoPanel;
    public Text infoText;

    public GameObject death;

    public Text scoreText;
    public Text livesText;

    private float speed;

    private float messageTime = 4.0f;
    private float waitTime = 8.0f;
    private float timer = 0.0f;  

    private string message1 = "Use LEFT and RIGHT ARROWS to avoid collision with asteroid!";
    private string message2 = "And collect COINS to get bonus life for each 10";

    private GameObject starTrigger;

    private int collisions;
    private int lives = 3; //LevelsLivesCounter.currentLivesNumber;

    Collider2D coll = new Collider2D();


    // METHODS
    // Start is called before the first frame update
    void Start()
    {
       

        LevelsLivesCounter.beginOfGame = false;

        rBody = GetComponent<Rigidbody2D>();
        score = 0;

        ShowScore();          

        ShowInfo(message1);


    }

 void Update()
    {

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


        //ShowLives(lives);

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
            //Debug.Log(lives);
            if (lives < 2)
            {
               // Debug.Log(lives);
                //Instantiate(death, transform.position, Quaternion.identity);
                Die();
            }
            else
            {
                LevelsLivesCounter.currentLivesNumber -= 1;

               // Debug.Log("Life " + lives);

                //Instantiate(death, transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);

                //LevelsLivesCounter.currentLivesNumber -= 1;


                //Application.LoadLevel("Level1");
                SceneManager.LoadScene("Level1");

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

            // LevelsLivesCounter.currentLivesNumber = lives;
            // LevelsLivesCounter.currentGameScore = score;

            //Application.LoadLevel("Level1_Post_Title");
            SceneManager.LoadScene("Level1_Post_Title");
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
                ShowLives(lives);
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

        // LevelsLivesCounter.currentLivesNumber = 3;
        // LevelsLivesCounter.currentGameScore = 0;

        //Application.LoadLevel("Die");
        SceneManager.LoadScene("Die");
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + score.ToString();
        Debug.Log(scoreText.text);
    }

     void ShowLives(int number)
    {
        livesText.text = "Lives : " + number.ToString();
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
