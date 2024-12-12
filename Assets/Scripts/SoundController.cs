using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
 
    private float globalVolume = 1.0f;

    public AudioSource OnClick;
    public AudioSource Correct;
    public AudioSource False;
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


    public void UpdateAudioSourceVolumes()
    {
        if (OnClick != null) 
            OnClick.volume = globalVolume;
        if (Correct != null) 
            Correct.volume = globalVolume;
        if (False != null) 
            False.volume = globalVolume;
    }
}
