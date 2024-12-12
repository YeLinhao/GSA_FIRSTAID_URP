using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeController : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public SoundController soundController;

    void Start()
    {
        slider = GetComponent<Slider>();
        soundController = SoundController.instance;
        AudioSource[] audioSources = soundController.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources) {
            if (soundController != null && slider != null)
            {
                slider.value = audioSource.volume;
                slider.onValueChanged.AddListener(OnVolumeChanged);
            }
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
        AudioSource[] audioSources = soundController.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = slider.value;
        }
    }
    public void OnVolumeChanged(float value)
    {
        if (soundController != null)
        {
            SetGlobalVolume(); 
        }
    }

}
