using UnityEngine;
using UnityEngine.Video;

public class PanelVideoController : MonoBehaviour
{
    public GameObject panel2; 
    public VideoPlayer videoPlayer;
    private bool isPanel2Active = false; 
    private float delayTime = 3f; 
    private float timer = 0f; 
    private void Update()
    {
        if (isPanel2Active)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                StartVideo();
                isPanel2Active = false; 
            }
        }
    }

    public void ActivatePanel2()
    {
        panel2.SetActive(true); 
        timer = 0f; 
        isPanel2Active = true;
    }

    public void DeactivatePanel2()
    {
        panel2.SetActive(false); 
        StopVideo(); 
    }

    private void StartVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            Debug.Log("Video Started!");
        }
    }

    private void StopVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop(); 
            Debug.Log("Video Stopped!");
        }
    }
}
