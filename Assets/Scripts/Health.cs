using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool shown = true;

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (!shown)
            {
                RemoveHealth();
            }
        }
        
    }

    public void RemoveHealth()
    {
        Destroy(this.gameObject);
    }
}
