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
        soundController = SoundController.instance;
        audioSource = soundController.GetComponent<AudioSource>();
        if(soundController != null && slider != null)
        {
            slider.value = audioSource.volume;
            slider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    private void Update()
    {
        if (soundController != null && slider != null)
        {
            slider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }
    public void SetGlobalVolume()
    {
        audioSource.volume = slider.value;
        soundController.UpdateAudioSourceVolumes();
    }
    public void OnVolumeChanged(float value)
    {
        if (soundController != null)
        {
            SetGlobalVolume(); 
        }
    }

}
