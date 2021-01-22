using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the playing of music in the game. Attached to a GameObject
/// that persists between scenes using DontDestroyOnLoad().
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    // Configuration parameters
    AudioSource musicSource;
    [SerializeField] AudioClip[] musicTracks;

    // State variables
    int musicTrackIndex;
    public bool musicPaused;

    /// <summary>
    /// Called by unity when the game object this script is attached to is first instantiated.
    /// Calls DontDestroyOnLoad(), as well as gets the music volume saved in playerprefs.
    /// </summary>
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

    /// <summary>
    /// Called by Unity once per frame. This updater checks if any music is currently playing, and starts
    /// the next song in the sequence if there is none.
    /// </summary>
    private void Update()
    {
        if (musicSource.isPlaying || musicPaused) { return; }
        musicSource.clip = musicTracks[musicTrackIndex++];
        musicTrackIndex %= musicTracks.Length;
        musicSource.Play();
    }

    /// <summary>
    /// Sets the volume of the music.
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    /// <summary>
    /// Pauses playing of the music.
    /// </summary>
    public void PauseMusic()
    {
        musicPaused = true;
        musicSource.Pause();
    }

    /// <summary>
    /// Begins/continues playing of the music track.
    /// </summary>
    public void PlayMusic()
    {
        musicPaused = false;
        musicSource.Play();
    }
}
