using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Thread.Sleep(1000); //Delay of splash screen for 1 sec

        Application.LoadLevel(1);
    }
}
