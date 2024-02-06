using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    public AudioSource audioFx;

    [Header("Audio Clips")]
    public AudioClip clickingSound;
    public AudioClip shootingSound;
    public AudioClip victorySound;
    public AudioClip defeatSound;

    public ScriptableObjectAudio audio;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitFXVolume();
    }

    public void InitFXVolume()
    {
        audioFx.volume = audio.audioVolume;
    }    

    public void ButtonClickSound()
    {
        audioFx.clip = clickingSound;
        audioFx.Play();
    }

    public void ShootingSound()
    {
        audioFx.clip = shootingSound;
        audioFx.Play();
    }

    public void VictorySound()
    {
        audioFx.clip = victorySound;
        audioFx.Play();
    }

    public void DefeatSound()
    {
        audioFx.clip = defeatSound;
        audioFx.Play();
    }
}
