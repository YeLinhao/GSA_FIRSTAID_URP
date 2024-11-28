using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Image fillImage; 
    public float countdownTime = 90f; 

    private float currentTime;

    void Start()
    {
        if (fillImage == null)
        {
            Debug.LogError("Fill Image is not assigned!");
            return;
        }

        
        currentTime = countdownTime;
        fillImage.fillAmount = 1f; 
    }

    void Update()
    {
        if (currentTime > 0)
        {
            
            currentTime -= Time.deltaTime;

           
            fillImage.fillAmount = Mathf.Clamp01(currentTime / countdownTime);
        }
        else
        {
            currentTime = 0;
            Debug.Log(" Finished!");
        }
    }
}