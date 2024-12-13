using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
 
    public static ScoreManager Instance;
    public float score;
    public float totalWaitingTime;
    public TMP_Text scoreText;
    public TMP_Text GameOverScore;
    public TMP_Text GameOverWaitTime;
    public GameObject Ambulance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + ((int)score).ToString();
        if (GameOverScore != null )
        {
            GameOverScore.text = "Total Score:" + ((int)score).ToString();
            
        }
        if (GameOverWaitTime != null)
        {
            GameOverWaitTime.text = "TimeWaited:" + ((int)totalWaitingTime).ToString() + " seconds";
        }
            
    }

    public void SetGameMode(int GameMode)
    {
        GameManager.Instance.GameMode = GameMode;
    }

    public void NextLevel()
    {

        GameManager.Instance.GameMode++;

        if (GameManager.Instance.GameMode % 3 == 2)//if still not change to another scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        else if (GameManager.Instance.GameMode % 3 == 0 || GameManager.Instance.GameMode % 3 == 1)//if switch to next scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    
    public void GameEnd()
    {
        Ambulance.SetActive(true);
        NPCController.Instance.ClearAllUIWhenFinished();
        NPCController.Instance.LockInputWhenFinished();
    }


}
