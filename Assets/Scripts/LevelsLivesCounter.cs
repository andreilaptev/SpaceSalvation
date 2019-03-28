using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLivesCounter : MonoBehaviour
{
    public static int initialLives = 3;

    public static int currentLivesNumber = 3;
    public static int currentLivesNumberLevel2 = 3;
    public static int currentLivesNumberLevel3 = 3;

    public static bool beginOfGame = true;

    public  int currentGameScore1;

    public static int currentGameScore;


    public static int NumberOfDeadEnemiesLevel3;
    public static int NumberOfDeadEnemiesLevel2;

    public static LevelsLivesCounter Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }



}
