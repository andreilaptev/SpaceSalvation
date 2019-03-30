using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Level1 : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletSpawnpointLeft;
    public GameObject bulletSpawnpointRight;

    public GameObject enemy_destroy;

    public float bulletSpeed;

    public Rigidbody2D bullet;

    public float waitTime;
    public int hitsToDie;

    private float currentTime, initialDelay, timer;
    private bool shot;
    private bool shootinEnabled = false;
    private int hits;


    private Level1End end;
    private GameObject sCont;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hits = 0;
        initialDelay = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            targetPlayer();

        // Initial shooting delay
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > initialDelay )
        {
            shootinEnabled = true;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("AAA");


        if (other.gameObject.tag == "PlayerBullet")
        {
            if (hits < hitsToDie)
            {
                hits += 1;


            }

            else
            {
                //Die();
                Destroy(gameObject);
          

                //end.endLevel1();

                //LevelsLivesCounter.currentGameScore += sCont.GetComponent<Level2ShipController>().score;

                //Debug.Log(sCont.score);

                SceneManager.LoadScene("Level1_Post_Title");


                //Debug.Log("Enemy dead" + LevelsLivesCounter.NumberOfDeadEnemiesLevel2);

                //SceneManager.LoadScene("Level1_Post_Title");

                //Debug.Log("Enemy dead");

                //SceneManager.LoadScene("Level2_Post_Title");
            }


        }


    }


    private void targetPlayer()
    {

        // TARGETING
        //Var1
        //this.transform.LookAt(player.transform);

        //Var2
        //transform.LookAt(Vector3.forward, Vector3.Cross(Vector3.forward, player.transform.position - this.transform.position));

        //Var3

        float angle = 0;
        if (player != null)
        {
            Vector3 relative = transform.InverseTransformPoint(player.transform.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
        }



        // SHOOTING DELAY
        if (currentTime == 0)
            Shoot();

        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;

        if (currentTime >= waitTime)
            currentTime = 0;
    }

    private void Shoot()
    {
        shot = true;

        Rigidbody2D bulletInstance;

        if (shootinEnabled)
        {
            bulletInstance = Instantiate(bullet, bulletSpawnpointLeft.transform.position, Quaternion.identity) as Rigidbody2D;

            bulletInstance.AddForce(bulletSpawnpointLeft.transform.up * bulletSpeed);

            bulletInstance = Instantiate(bullet, bulletSpawnpointRight.transform.position, Quaternion.identity) as Rigidbody2D;

            bulletInstance.AddForce(bulletSpawnpointRight.transform.up * bulletSpeed);
        }
        

        

        //Debug.Log("shot");

    }


    private void Die()
    {
        Instantiate(enemy_destroy, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
