using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int nextPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(nextPage);
#pragma warning restore CS0618 // Type or member is obsolete

        }
    }
}
