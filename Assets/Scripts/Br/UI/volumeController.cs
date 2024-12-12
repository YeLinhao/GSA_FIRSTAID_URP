using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeController : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public SoundController soundController;
    public AudioSource audioSource;
    

    void Start()
    {
        slider = GetComponent<Slider>();
        soundController = FindObjectOfType<SoundController>();
        audioSource = soundController.GetComponent<AudioSource>();
        if(soundController == null && slider != null)
        {
            slider.value = soundController.GetGlobalVolume();
            slider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    private void Update()
    {
        if(soundController == null) {
            soundController = FindObjectOfType<SoundController>();
            audioSource = soundController.GetComponent<AudioSource>();
        }
    }

    public void OnVolumeChanged(float value)
    {
        if (soundController != null)
        {
            SetGlobalVolume(); 
        }
    }
    public void SetGlobalVolume()
    {
        audioSource.volume = slider.value * .05f;
        soundController.UpdateAudioSourceVolumes();
    }
}
