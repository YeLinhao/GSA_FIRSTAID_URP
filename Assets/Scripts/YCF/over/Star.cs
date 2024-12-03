using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    
  
  
    [SerializeField] private float SocreNum = 0f;

    public Text ScoreText;

    private float currentFillTime;

    public GameObject winPanel;

    public GameObject[] stars;


    void Start()
    {
        
        ScoreText.text = SocreNum.ToString();
    }

    void Update()
    {
      
        Timer();
    }

    private void Timer()
    {
        
            if (currentFillTime <= 0)
            {             

                StartCoroutine("ShowStarts");
            }
        
    }


    IEnumerator ShowStarts()
    {
        winPanel.SetActive(true);

        if (SocreNum < 4)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);

        }
        else if (SocreNum < 6)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);

        }
        else
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);

        }
    }




}


