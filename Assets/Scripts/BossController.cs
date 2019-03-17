using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject dropPoint1;
    public GameObject dropPoint2;
    public GameObject dropPoint3;
    public GameObject dropPoint4;
    public GameObject dropPoint5;
    public GameObject dropPoint6;

    public GameObject nucleaDropPoint1;
    public GameObject nucleaDropPoint2;

    public Rigidbody2D bomb;
    public Rigidbody2D nuclearBomb;

    public int health;

    public float waitTime;
    private float currentTime = 0;
    private bool shot;

    void Start()
    {
        
    }

    /// <summary>
  
    // Update is called once per frame
    void Update()
    {
        

        if (health <= 0)
            Die();


        // SHOOTING DELAY
        if (currentTime == 0)
           DropBombs();

        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;

        if (currentTime >= waitTime)
            currentTime = 0;
        


      
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerNuclearBullet")
        {
            health -= 25;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PlayerBullet")
        {
            health -= 5;
            Destroy(other.gameObject);
        }
    }

    private void DropBombs()
    {
        shot = true;

        Rigidbody2D bombInstance;
        Rigidbody2D nuclearBombInstance;

        bombInstance = Instantiate(bomb, dropPoint1.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint2.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint3.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint4.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint5.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint6.transform.position, Quaternion.identity);

        nuclearBombInstance = Instantiate(nuclearBomb, nucleaDropPoint1.transform.position, Quaternion.identity);
        nuclearBombInstance = Instantiate(nuclearBomb, nucleaDropPoint2.transform.position, Quaternion.identity);
    }
}
