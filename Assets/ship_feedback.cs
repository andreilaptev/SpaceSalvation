﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_feedback : MonoBehaviour
{
    public float time;

    void Start()
    {
        Destroy(gameObject, time);
    }

    
}
