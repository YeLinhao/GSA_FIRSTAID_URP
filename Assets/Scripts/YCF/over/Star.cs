using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    public int OneStarScore;
    public int TwoStarScore;
    public int ThreeStarScore;


    private float currentFillTime;

    public GameObject winPanel;

    public GameObject[] stars;


    void Start()
    {
        

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

        if (ScoreManager.Instance.score >= OneStarScore && ScoreManager.Instance.score < TwoStarScore)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);

        }
        else if (ScoreManager.Instance.score >= TwoStarScore && ScoreManager.Instance.score < ThreeStarScore)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);

        }
        else if (ScoreManager.Instance.score >= ThreeStarScore)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);

        }
    }




}


