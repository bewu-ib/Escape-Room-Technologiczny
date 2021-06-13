using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource effects;

    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip applause;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            playEffect(applause);
        }
    }

    public void playEffect(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }
}
