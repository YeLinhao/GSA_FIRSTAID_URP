using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIcontrol : MonoBehaviour

{
    public Animator animator;
    public GameObject GameOverPanel;
    public string HomePanel;
    public string nextSceneName;

    private void Start()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }
    }


    public void OnAnimationEnd()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
    }


    public void LoadMainMenu()
    {
        if (!string.IsNullOrEmpty(HomePanel))
        {
            SceneManager.LoadScene(HomePanel);
        }
        else
        {
            Debug.LogError("00Begin");
        }
    }

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("02Level 2");
        }
    }


    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}