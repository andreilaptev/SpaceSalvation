using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Level1_Title_Delay : MonoBehaviour
{
    public int score;
    public int lives;


    public Text scoreText;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        score = ShipController.levelScore;
        Debug.Log(score);

        lives = LevelsLivesCounter.currentLivesNumber;
        Debug.Log(lives);

        scoreText.text = "Your Current Score : " + score.ToString();
        livesText.text = "Lives Available : " + lives.ToString();

    }

    void Update()
    {
        //text = scoreText.GetComponent<Text>();
        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
            Application.LoadLevel(0);
        }

        //Debug.Log("1 run");

        //Thread.Sleep(5000); //Delay of Title screen for 3 sec

        //Debug.Log("2 run");

        //
    }

}