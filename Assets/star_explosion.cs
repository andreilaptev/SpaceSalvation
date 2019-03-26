using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_explosion : MonoBehaviour
{
    public float time = 0.2f;

    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, time);
    }
}
