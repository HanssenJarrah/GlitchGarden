using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "masterVolume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    public const float DEFAULT_MASTER_VOLUME = 0.8f;
    public const float DEFAULT_DIFFICULTY = 0.5f;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) // If this preference has never been set
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, DEFAULT_MASTER_VOLUME);
        }
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY))    // If this preference has never been set
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, DEFAULT_DIFFICULTY);
        }
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master volume set outside valid range.");
        }
    }

    public static float GetMasterVolume()
    {
        float volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            return volume;
        } else
        {
            Debug.LogError("Master volume was set externally outside valid range.");
            return DEFAULT_MASTER_VOLUME;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
