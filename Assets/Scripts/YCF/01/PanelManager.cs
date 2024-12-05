using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject introPanel; 
    public GameObject videoPanel; 
    void Start()
    {
        
        introPanel.SetActive(true);
        videoPanel.SetActive(false);
    }

    
    public void CloseIntroPanel()
    {
        introPanel.SetActive(false); 
    }


    public void CloseVideoPanel()
    {
        videoPanel.SetActive(false);
    }
}
