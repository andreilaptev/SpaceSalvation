using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
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
    }
}
