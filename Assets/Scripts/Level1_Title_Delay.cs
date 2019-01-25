using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Level1_Title_Delay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {

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