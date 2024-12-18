using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CountdownManager : MonoBehaviour
{
    public Text countdownText; 
    public Image timeFillImage;
    public GameObject Ambulance;

    public float fillCountdownDuration; 
    public float currentFillTime;
   

    void Start()
    {
        StartCoroutine(StartCountdown());
        Ambulance.SetActive(false);

        if (GameManager.Instance.GameMode % 3 == 1)
        {
            fillCountdownDuration = 150f;
        }

        if (GameManager.Instance.GameMode % 3 == 2)
        {
            fillCountdownDuration = 70f;
        }
    }

 
    private IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); 
            yield return new WaitForSeconds(1f); 
        }

        countdownText.gameObject.SetActive(false);
        StartFillCountdown(); 
    }

    
    private void StartFillCountdown()
    {
        timeFillImage.fillAmount = 1f; 
        currentFillTime = fillCountdownDuration;
        StartCoroutine(FillCountdown());
    }

    
    private IEnumerator FillCountdown()
    {
        while (currentFillTime > 0)
        {
            currentFillTime -= Time.deltaTime; 
            timeFillImage.fillAmount = currentFillTime / fillCountdownDuration; 
            yield return null;
        }

        //time is up
        Ambulance.SetActive(true);
        NPCController.Instance.ClearAllUIWhenFinished();
        NPCController.Instance.LockInputWhenFinished();
    }

    


   
}
