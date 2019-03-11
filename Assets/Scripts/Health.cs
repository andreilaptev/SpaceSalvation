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
            if (other.gameObject.tag == "Player") //(!shown)
            {

                Debug.Log("remove health");
                RemoveHealth();
            }
        }   
        
        
    }

    public void RemoveHealth()
    {
        Destroy(this.gameObject);
    }
}
