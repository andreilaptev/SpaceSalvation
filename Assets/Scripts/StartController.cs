using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Thread.Sleep(1500); //Delay of splash screen for 1 sec

        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
