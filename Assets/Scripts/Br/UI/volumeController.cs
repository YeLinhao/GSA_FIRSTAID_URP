using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeController : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public AudioSource audiobg;
    public void VolumeController()
    {
        audiobg.volume = slider.value * .05f;
    }
}
