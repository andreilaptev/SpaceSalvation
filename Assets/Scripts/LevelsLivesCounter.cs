﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsLivesCounter 
{
    public static int initialLives = 3;

    public static int currentLivesNumber = 3;
    public static int currentLivesNumberLevel2 = 3;
    public static int currentLivesNumberLevel3 = 3;

    public static bool beginOfGame = true;


    public static int currentGameScore
    {
        get
        {
            return currentGameScore;
        }
        set
        {
            currentGameScore = value;
        }
    }

    public static int NumberOfDeadEnemiesLevel3;
    public static int NumberOfDeadEnemiesLevel2;

    

    

}
