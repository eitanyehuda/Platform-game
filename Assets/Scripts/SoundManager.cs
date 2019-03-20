using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance = null;

    public AudioClip jump;
    public AudioClip getCoin;
    public AudioClip rockSmash;
    public AudioClip mannyDies;


    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start () {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();

        soundEffectAudio = theSource;

	}

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
