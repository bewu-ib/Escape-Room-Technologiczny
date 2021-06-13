using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void saveSoundEffects(float value)
    {
        audioMixer.SetFloat("SoundEffectsVol", value);
    }

    public void saveMusic(float value)
    {
        audioMixer.SetFloat("MusicVol", value);
    }

    public void saveSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
