using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int nextPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log(LevelsLivesCounter.currentLivesNumber);

            //Application.LoadLevel(nextPage);
            SceneManager.LoadScene(nextPage);
        }
    }
}
