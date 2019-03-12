using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bossPoint;
    public Rigidbody2D boss;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBoss()
    {
        Rigidbody2D bossInstance;

        bossInstance = Instantiate(boss, bossPoint.transform.position, Quaternion.identity);
    }
}
