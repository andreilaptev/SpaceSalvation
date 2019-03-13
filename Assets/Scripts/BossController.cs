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


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D bombInstance;
        Rigidbody2D nuclearBombInstance;

        bombInstance = Instantiate(bomb, dropPoint1.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint2.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint3.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint4.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint5.transform.position, Quaternion.identity);
        bombInstance = Instantiate(bomb, dropPoint6.transform.position, Quaternion.identity);

        nuclearBombInstance = Instantiate(bomb, nucleaDropPoint1.transform.position, Quaternion.identity);
        nuclearBombInstance = Instantiate(bomb, nucleaDropPoint2.transform.position, Quaternion.identity);
    }

    
}
