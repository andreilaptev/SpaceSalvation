﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 7f;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("LLL");

            //float horiz = Input.GetAxis("Horizontal");
            //rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        }


        // Listen for Space to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rBody.gravityScale = -2;
            rBody.AddForce(new Vector2(0, 500));
        }

        // Flipping NOT WORKING SO FAR
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");    


        //float vert = Input.GetAxis("Vertical"); // Not good - gravity pulls player down 
        
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
    }
}
