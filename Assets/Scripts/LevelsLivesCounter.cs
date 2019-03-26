using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLivesCounter : MonoBehaviour
{

    public static int currentLivesNumber = 3;
    public static int currentLivesNumberLevel2 = 3;
    public static int currentLivesNumberLevel3 = 3;

    public static int currentGameScore;

    public static int NumberOfDeadEnemiesLevel3;
    public static int NumberOfDeadEnemiesLevel2;

    void Start()
    {
        NumberOfDeadEnemiesLevel3 = 0;
        NumberOfDeadEnemiesLevel2 = 0;
    }

}
