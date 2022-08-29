using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    //Attach Script To A SoundEffect Manager
    [SerializeField]
    private AudioSource audioSource, winSource;

    [SerializeField]
    private AudioClip attachSound, detachSound, winSound, waterSound, selectSound;

    public void PlayAttachSound(float volume = 1) 
    {
        audioSource.pitch = 1;
        audioSource.volume = volume;
        audioSource.clip = attachSound;
        audioSource.Play();
    }
    public void PlayDetachSound(float volume = 1) 
    {
        audioSource.pitch = 0.8f;
        audioSource.volume = volume;
        audioSource.clip = detachSound;
        audioSource.Play();
    }

    public void PlayWinSound(float volume = 1) 
    {
        winSource.pitch = 1;
        winSource.volume = volume;
        winSource.clip = winSound;
        winSource.Play();
    }

    public void PlayWaterSound(float volume = 1) 
    {
        audioSource.pitch = Random.Range(1, 1.3f);
        audioSource.volume = volume;
        audioSource.clip = waterSound;
        audioSource.Play();
    }

    public void PlaySelctSound(float volume = 1) 
    {
        audioSource.pitch = Random.Range(1, 1.2f);
        audioSource.volume = volume;
        audioSource.clip = selectSound;
        audioSource.Play();
    }
}
