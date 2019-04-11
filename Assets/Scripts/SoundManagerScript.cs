using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fireSound, enemyFireSound, playerDeathSound, enemyDeathSound, bombSound, explosionSound, damageSound, powerUpSound, boostSound, collectCoinSound, collectHealthSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip> ("laser-sfx");
        enemyFireSound = Resources.Load<AudioClip> ("laser-02");
        playerDeathSound = Resources.Load<AudioClip> ("");
        enemyDeathSound = Resources.Load<AudioClip> ("");
        bombSound = Resources.Load<AudioClip>("bomb");
        explosionSound = Resources.Load<AudioClip> ("explosionbombblastambient2");
        damageSound = Resources.Load<AudioClip>("damage-sound-effect");
        powerUpSound = Resources.Load<AudioClip>("8bit-powerup");
        boostSound = Resources.Load<AudioClip>("rocket-boost-engine-loop");
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
            case "bomb":
                audioSrc.PlayOneShot(bombSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
            case "damage":
                audioSrc.PlayOneShot(damageSound);
                break;
            case "powerUp":
                audioSrc.PlayOneShot(powerUpSound);
                break;
            case "boost":
                audioSrc.PlayOneShot(boostSound);
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
