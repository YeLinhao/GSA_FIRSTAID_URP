using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public GameObject introductionPanel; 
    private void Start()
    {
        if (introductionPanel != null)
        {
            
            introductionPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Introduction Panel δ���ã�");
        }
    }

    
    public void CloseIntroductionPanel()
    {
        if (introductionPanel != null)
        {
            introductionPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Introduction Panel δ���ã�");
        }
    }
}
