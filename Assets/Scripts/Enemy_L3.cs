using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_L3 : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletSpawnpointLeft;
    public GameObject bulletSpawnpointRight;
    public float bulletSpeed;

    public Rigidbody2D bullet;

    public float waitTime;
    public int hitsToDie;

    private float currentTime;
    private bool shot;
    private int hits;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            targetPlayer();

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
                Die();

                //Debug.Log("Enemy dead");

                SceneManager.LoadScene("Level2_Post_Title");
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

        bulletInstance = Instantiate(bullet, bulletSpawnpointLeft.transform.position, Quaternion.identity) as Rigidbody2D;

        bulletInstance.AddForce(bulletSpawnpointLeft.transform.up * bulletSpeed);

        bulletInstance = Instantiate(bullet, bulletSpawnpointRight.transform.position, Quaternion.identity) as Rigidbody2D;

        bulletInstance.AddForce(bulletSpawnpointRight.transform.up * bulletSpeed);

        //Debug.Log("shot");

    }


    private void Die()
    {

        Destroy(gameObject);
    }
}
