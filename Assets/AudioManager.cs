using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("Audio Source on audio manager cannot be referenced!");
        }

        audioSrc.Play();

        DontDestroyOnLoad(this);
    }
}

