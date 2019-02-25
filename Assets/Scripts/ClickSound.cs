using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool playOnCreate = false;
    void Start()
    {
        if(playOnCreate)
        {
            playClip();
        }
    }

    public void playClip(){
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
