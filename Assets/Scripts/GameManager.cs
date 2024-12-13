using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int GameMode = -1;
    // Fac-tutorial:0 Fac-Easy:1 Fac-Crazy:2
    // Class-tutorial:3 Class-Easy:4 Class-Crazy:5
    // Park-tutorial:6 Park-Easy:7 Park-Crazy:8


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    public void SetGameMode(int ChangeToGamemode){
        GameMode = ChangeToGamemode;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit()
    {
        Application.Quit();
    }


}
