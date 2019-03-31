using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fireSound, enemyFireSound, playerDeathSound, enemyDeathSound, explosionSound, damageSound, collectCoinSound, collectHealthSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip> ("laser-sfx");
        enemyFireSound = Resources.Load<AudioClip> ("laser-02");
        playerDeathSound = Resources.Load<AudioClip> ("");
        enemyDeathSound = Resources.Load<AudioClip> ("");
        explosionSound = Resources.Load<AudioClip> ("big-explosion");
        damageSound = Resources.Load<AudioClip>("");
        collectCoinSound = Resources.Load<AudioClip> ("coin-get");
        collectHealthSound = Resources.Load<AudioClip>("health-1");

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
            case "damage":
                audioSrc.PlayOneShot(damageSound);
                break;
            case "collectCoin":
                audioSrc.PlayOneShot(collectCoinSound);
                break;
            case "collectHealth":
                audioSrc.PlayOneShot(collectHealthSound);
                break;
        }
    }
}
