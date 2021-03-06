﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public bool shown = true;
    public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        if (!shown)
        {
            RemoveStar();
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy")
        {
            RemoveStar();
        }
    }

    public void RemoveStar()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
