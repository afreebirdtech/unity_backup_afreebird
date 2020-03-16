using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip birdfly, birddie, finishgame;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void BirdFlySound()
    {
        source.clip = birdfly;
        source.Play();
    }

    public void BirdDiedSound()
    {
        source.clip = birddie;
        source.Play();
    }

    public void FinishGameSound()
    {
        source.clip = finishgame;
        source.Play();
    }
}
