using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private GameObject introductionPanel; 
    private bool isIntroductionClosed = false;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        
        if (introductionPanel != null && introductionPanel.activeSelf)
        {
            numberText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        
        if (GameManager.Instance.IsCountDownState() && isIntroductionClosed)
        {
            numberText.text = Mathf.CeilToInt(GameManager.Instance.GetCountDownTimer()).ToString();
        }
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        
        if (GameManager.Instance.IsCountDownState() && isIntroductionClosed)
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
            numberText.gameObject.SetActive(false);
        }
    }

    
    public void CloseIntroductionPanel()
    {
        if (introductionPanel != null)
        {
            introductionPanel.SetActive(false);
            isIntroductionClosed = true; 
           
            if (GameManager.Instance.IsCountDownState())
            {
                numberText.gameObject.SetActive(true);
            }
        }
    }
}
