using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


        }
    


    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
        GameisPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
    }



    public void LoadScene(string a)
    {
        SceneManager.LoadScene(a);
    }

    public void QuitApplication()
    {
        Debug.Log("App out!");
        Application.Quit();
    }
}
