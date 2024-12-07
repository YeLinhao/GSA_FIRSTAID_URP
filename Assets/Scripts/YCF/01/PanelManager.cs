using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject introPanel; 
    public GameObject videoPanel; 
    void Start()
    {
        
        introPanel.SetActive(true);
        
    }

    
    public void CloseIntroPanel()
    {
        introPanel.SetActive(false); 
    }


    public void CloseVideoPanel()
    {
        for (int i = 0; i < videoPanel.transform.childCount; i++)
        {
            Transform child = videoPanel.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        
    }
}
