using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Image fillImage; 
    public Button pauseButton; 
    public GameObject panel; 

    private bool isPaused = false; 
    private float countdownTime = 10f; 
    private float currentTime; 

    private void Start()
    {
        
        currentTime = countdownTime;

        
        pauseButton.onClick.AddListener(TogglePause);
    }



    private void TogglePause()
    {
        
        isPaused = !isPaused;
        
    }

    public void ClosePanel()
    {
        
        isPaused = false;
        panel.SetActive(false);
        
    }
}