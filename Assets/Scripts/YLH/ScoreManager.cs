using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
 
    public static ScoreManager Instance;
    public int score;
    public TMP_Text scoreText;
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
        scoreText.text = "Score:" + score.ToString();
    }
}
