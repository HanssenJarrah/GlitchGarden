using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Configuration parameters
    AudioSource musicSource;
    [SerializeField] AudioClip[] musicTracks;

    // State variables
    int musicTrackIndex;
    public bool musicPaused;

    private void Start()
    {
        DontDestroyOnLoad(this);

        // Ensures there are not duplicate music players when the game returns to main menu.
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }

        musicSource = GetComponent<AudioSource>();
        musicSource.volume = PlayerPrefsController.GetMasterVolume();

        musicTrackIndex = 0;
        musicPaused = false;
    }

    private void Update()
    {
        if (musicSource.isPlaying || musicPaused) { return; }
        musicSource.clip = musicTracks[musicTrackIndex++];
        musicTrackIndex %= musicTracks.Length;
        musicSource.Play();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void PauseMusic()
    {
        musicPaused = true;
        musicSource.Pause();
    }

    public void PlayMusic()
    {
        musicPaused = false;
        musicSource.Play();
    }
}
