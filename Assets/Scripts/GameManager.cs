using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int GameMode = -1; // if tutorial:0, if gamemode 1/2/3



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
}
