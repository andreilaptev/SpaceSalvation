using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound, enemyFireSound, playerDeathSound, enemyDeathSound, explosionSound, collectItemSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip> ("");
        enemyFireSound = Resources.Load<AudioClip> ("");
        playerDeathSound = Resources.Load<AudioClip> ("");
        enemyDeathSound = Resources.Load<AudioClip> ("");
        explosionSound = Resources.Load<AudioClip> ("");
        collectItemSound = Resources.Load<AudioClip> ("");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "enemyFire":
                audioSrc.PlayOneShot(enemyFireSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
            case "collectItem":
                audioSrc.PlayOneShot(collectItemSound);
                break;
        }
    }
}
