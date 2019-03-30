using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_L3 : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletSpawnpointLeft;
    public GameObject bulletSpawnpointRight;
    public float bulletSpeed;
    public GameObject bombPoint;
    public GameObject bossPoint;

    public Rigidbody2D bullet;
    public Rigidbody2D bomb;
    public Rigidbody2D boss;

    public float waitTime;
    public int hitsToDie;

    private float currentTime,initialDelay, timer;
    private bool shootinEnabled = false;
    private bool shot;
    private int hits;

    private int numberOfDeadEnemies = 0;
    private string currentScene;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hits = 0;

        currentScene = SceneManager.GetActiveScene().name;

        LevelsLivesCounter.NumberOfDeadEnemiesLevel3 = 0;

        initialDelay = 3.0f;
        //Debug.Log(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            targetPlayer();


        // Initial shooting delay
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > initialDelay)
        {
            shootinEnabled = true;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
    

        if (other.gameObject.tag == "PlayerBullet")
        {
            if (hits < hitsToDie)
            {
                hits += 1;

                
            }

            else
            {
                // Here comes the Main Enemy
                Die();

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
        Destroy(gameObject);

        // Incrementing number of dead enemies 
        LevelsLivesCounter.NumberOfDeadEnemiesLevel3 += 1;

        //Debug.Log(LevelsLivesCounter.NumberOfDeadEnemiesLevel3);


        if (LevelsLivesCounter.NumberOfDeadEnemiesLevel3 == 1 && currentScene == "Level2")
            SceneManager.LoadScene("Level2_Post_Title");

        if (LevelsLivesCounter.NumberOfDeadEnemiesLevel3 == 2 && currentScene == "Level3")    
                ShowBoss();

        // Droppung a bomb
        Rigidbody2D bombInstance;

        bombInstance = Instantiate(bomb, bombPoint.transform.position, Quaternion.identity) as Rigidbody2D;
        //  SceneManager.LoadScene("Level2_Post_Title");

    }



    private void ShowBoss()
    {

        Rigidbody2D bossInstance;

        bossInstance = Instantiate(boss, bossPoint.transform.position, Quaternion.identity);
    }
}
