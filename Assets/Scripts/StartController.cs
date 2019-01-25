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
        Thread.Sleep(2000);

        Application.LoadLevel(1);
    }
}
