using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo3Level : MonoBehaviour
{
    public void GoToLevel3()
    {
        Debug.Log("go to 3");
        SceneManager.LoadScene("Level3");
    }
}
