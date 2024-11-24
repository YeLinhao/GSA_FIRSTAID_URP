using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class E : MonoBehaviour
{
    public GameObject videoPanel; 
    public VideoPlayer videoPlayer; 

    private bool isVideoPlaying = false; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isVideoPlaying)
            {
                CloseVideo();
            }
            else
            {
                OpenVideo();
            }
        }
    }


    void OpenVideo()
    {
        if (videoPanel != null && videoPlayer != null)
        {
            videoPanel.SetActive(true); 
            videoPlayer.Play();
            isVideoPlaying = true;
        }
    }

   
    void CloseVideo()
    {
        if (videoPanel != null && videoPlayer != null)
        {
            videoPlayer.Stop(); 
            videoPanel.SetActive(false); 
            isVideoPlaying = false; 
        }
    }
}
