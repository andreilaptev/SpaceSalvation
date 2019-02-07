using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CombatMusicControl : MonoBehaviour
{

    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioClip[] laserBeams;
    public AudioSource laserBeamSource;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Start is called before the first frame update
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            inCombat.TransitionTo(m_TransitionIn);
            PlayLaserBeam();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }
    }

    void PlayLaserBeam()
    {
        int randClip = Random.Range(0, laserBeams.Length);
        laserBeamSource.clip = laserBeams[randClip];
        laserBeamSource.Play();
    }
}
