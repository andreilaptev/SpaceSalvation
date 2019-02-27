using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue_beam : MonoBehaviour
{
    public float speed;
       
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
