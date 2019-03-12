using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_3_Controller : MonoBehaviour
{
    private float timeSpan = 0;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level started");
    }

    // Update is called once per frame
    void Update()
    {
        //enemy = GameObject.FindWithTag("Enemy");

        //if (enemy == null && !ReferenceEquals(enemy, null))
        //    Debug.Log("No enemies");

        //if (enemy != null)
        //    Debug.Log("Enemy exists");
        //else
        //    Debug.Log("No enemies");

    }
}
