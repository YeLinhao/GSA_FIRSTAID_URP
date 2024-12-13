using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
 
    private float globalVolume = 1.0f;
    private float storeVolume;

    public AudioSource OnClick;
    public AudioSource Correct;
    public AudioSource False;

    public bool isQuiet = false;
    // Start is called before the first frame update
    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }      
    }

    void Update()
    {

    }


    public void PlayOnClick() 
    {
        if(OnClick != null)
        {
            OnClick.Play();
        }
    }


    public void PlayCorrect()
    {
        Correct.Play();
    }

    public void PlayFalse()
    {
        False.Play();
    }

    public void PlayFinish()
    {

    }

    public void BeQuiet()
    {
        isQuiet = true;
        storeVolume = globalVolume;
        globalVolume = 0f;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = globalVolume;
        }

    }

    public void DontBeQuiet()
    {
        if (isQuiet == true) {
            globalVolume = storeVolume;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            isQuiet = false;
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.volume = globalVolume * .2f;
            }
        }
    }

    public void LowerVolume() {
        globalVolume = globalVolume * .2f;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = globalVolume;
        }
    }

    public void RaiseVolume() {
        globalVolume = globalVolume / .2f;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = globalVolume;
        }
    }
}
