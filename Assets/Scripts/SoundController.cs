using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
 
    public AudioSource OnClick;
    public AudioSource Correct;
    public AudioSource False;
    // Start is called before the first frame update
    void Awake() 
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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

    private void Update()
    {
        
    }
}
