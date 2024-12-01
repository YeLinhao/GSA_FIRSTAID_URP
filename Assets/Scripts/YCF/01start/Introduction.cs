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
            Debug.LogError("Introduction Panel Œ¥…Ë÷√£°");
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
            Debug.LogError("Introduction Panel Œ¥…Ë÷√£°");
        }
    }
}
