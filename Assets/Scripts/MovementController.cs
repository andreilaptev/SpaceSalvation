using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        //Plane movPlane = new Plane(Vector3.up, transform.position);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float dist = 0.0f;

        //if(movPlane.Raycast(ray, out dist))
        //{
        //    Vector3 targetPoint = ray.GetPoint(dist);
        //    Quaternion rotation = Quaternion.LookRotation(targetPoint - transform.position);
        //    rotation.x = 0;
        //    rotation.y = 0;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 7f * Time.deltaTime);
        //}

        

        transform.Translate(0, speed*Time.deltaTime, 0);

        faceMouse();

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Debug.Log("Up");
        //    //rigidBody.velocity = transform.forward * speed;
        //    transform.Translate(Vector3.forward * speed*Time.deltaTime, Space.World);
        //}

    }

     void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;

        if (mousePosition.x == transform.position.x && mousePosition.y == transform.position.y)
        {
            Debug.Log("Met");
        }

        
        //Debug.Log("Mouse " + mousePosition);
        //Debug.Log("Ship " + transform.position);


    }
}
