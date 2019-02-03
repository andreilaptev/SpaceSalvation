using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public bool shown = true;

    // Update is called once per frame
    void Update()
    {
        if (!shown)
        {
            RemoveStar();
        }
    }

    public void RemoveStar()
    {
        Destroy(this.gameObject);
    }
}
