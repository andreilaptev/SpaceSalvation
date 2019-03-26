using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public GameObject feedback;

    public bool shown = true;

    private Rigidbody2D rBody;
    private float maxDistance;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
       // rBody.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);


        maxDistance += 1 * Time.deltaTime;

        if (maxDistance > 2) Destroy(this.gameObject);

        if (!shown)
            RemoveThisObject();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
            RemoveThisObject();
    }

    private void RemoveThisObject()
    {
        Instantiate(feedback, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}


