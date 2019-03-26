using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public GameObject hit;

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
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("Collision");
            RemoveThisObject();
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("trigger");
            RemoveThisObject();
        }
            
    }

        private void RemoveThisObject()
    {
        Instantiate(hit, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
