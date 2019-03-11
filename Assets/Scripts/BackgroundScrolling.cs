using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeeed = 0.05f;

    void Start()
    {
        // Background in chunks - calling MoveBG after 0.5 sec each 0.6 sec
        //InvokeRepeating("MoveBG", 0.5f, 0.6f);
    }


    // Update is called once per frame
    void Update()
    {
        //Constant background moving
        GetComponent<Renderer>().material.mainTextureOffset =
           new Vector2(Time.time * scrollSpeeed, 0);


    }

    void MoveBG()
    {
        GetComponent<Renderer>().material.mainTextureOffset =
               new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + scrollSpeeed, 0);
    }
}
