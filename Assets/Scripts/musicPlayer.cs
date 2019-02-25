using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Music");
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        if (gos.Length > 1)
        {
            Destroy(gameObject);
        } 
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}