using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1End : MonoBehaviour
{
    private Level2ShipController sCont;

    public void endLevel1()
    {
        LevelsLivesCounter.currentGameScore += sCont.score;

        Debug.Log(LevelsLivesCounter.currentGameScore);

        SceneManager.LoadScene("Level1_Post_Title");

    }
}
