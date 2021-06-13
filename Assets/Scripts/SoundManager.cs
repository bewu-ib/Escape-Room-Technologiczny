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
    public AudioClip startup;

    public void playEffect(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }
}
