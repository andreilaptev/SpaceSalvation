using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour
{
    private GameObject ship;
    private string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D cc = gameObject.AddComponent<CircleCollider2D>();
        cc.radius = 0.3f;
        cc.isTrigger = true;

        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        gameObject.transform.position = mousePosition;

        //Debug.Log(gameObject.transform.position.x);
        //Debug.Log(gameObject.transform.position.y);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Entered");
            ship = other.gameObject;

            ship.GetComponent<Level2ShipController>().atCursor = true;

            //if (currentScene == "Level2")     
            //    ship.GetComponent<Level2ShipController>().atCursor = true;            

            //else
            //    ship.GetComponent<Level3Ship>().atCursor = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Exit");
            ship = other.gameObject;

            ship.GetComponent<Level2ShipController>().atCursor = false;

            //if (currentScene == "Level2")
            //    ship.GetComponent<Level2ShipController>().atCursor = false;
            //else
            //    ship.GetComponent<Level3Ship>().atCursor = false;
            
        }
    }
}
