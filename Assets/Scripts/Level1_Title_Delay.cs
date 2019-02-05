using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Level1_Title_Delay : MonoBehaviour
{
    public int score;
    //private GameObject scoreText;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = ShipController.levelScore;
        Debug.Log(score);

        
    }

    void Update()
    {
        //text = scoreText.GetComponent<Text>();
        text.text = "Your Current Score : " + score;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
            Application.LoadLevel(3);
        }

        //Debug.Log("1 run");

        //Thread.Sleep(5000); //Delay of Title screen for 3 sec

        //Debug.Log("2 run");

        //
    }

}