using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveStar()
    {
        Destroy(this.gameObject);
    }
}
