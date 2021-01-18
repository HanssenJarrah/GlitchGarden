using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Slider volumeSlider;

    // State variables
    MusicPlayer musicPlayer;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();

        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!musicPlayer)
        {
            Debug.LogError("No music player found. The game must be started from the start screen.");
        }
    }

    private void Update()
    {
        if (!musicPlayer) { return; }
        musicPlayer.SetVolume(volumeSlider.value);
    }

    public void SaveOptionsAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);

        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void ResetSlidersToDefault()
    {
        volumeSlider.value = PlayerPrefsController.DEFAULT_MASTER_VOLUME;
    }
}
