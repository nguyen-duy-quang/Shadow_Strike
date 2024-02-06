using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip audioClip;

    public ScriptableObjectAudio audio;

    void Start()
    {
        InnitMusicVolume();
        PlayAudioMenu();
    }

    public void InnitMusicVolume()
    {
        musicSource.volume = audio.audioVolume;
    }

    private void PlayAudioMenu()
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }   
}
