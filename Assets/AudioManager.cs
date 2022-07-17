using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSrc;
    [SerializeField] AudioClip winSound, nothingSound, rotateSound, teleportSound, tileTSound, reverseMSound, conditionOffSound;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("Audio Source on audio manager cannot be referenced!");
        }
    }

    public void TriggerWinSound()
    {
        audioSrc.PlayOneShot(winSound);
    }

    public void TriggerNothingSound()
    {
        audioSrc.PlayOneShot(nothingSound);
    }
    public void TriggerRotateSound()
    {
        audioSrc.PlayOneShot(rotateSound);
    }
    public void TriggerTeleportSound()
    {
        audioSrc.PlayOneShot(teleportSound);
    }
    public void TriggerToggleTileSound()
    {
        audioSrc.PlayOneShot(tileTSound);
    }
    public void TriggerReverseMoveSound()
    {
        audioSrc.PlayOneShot(reverseMSound);
    }
    public void TriggerOffSound()
    {
        audioSrc.PlayOneShot(conditionOffSound);
    }

}

