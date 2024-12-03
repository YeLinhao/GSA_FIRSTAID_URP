using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // 倒计时， [SerializeField]可以将private类型的变量再unity面板中显示
    [SerializeField] private float timer = 60f;
    // 金币数量
    [SerializeField] private float SocreNum = 0f;

    // 显示时间和金币数的Text组件
    public Text timerText;
    public Text ScoreText;


    private bool isTimeOut = false;


    public GameObject winPanel;
   
    public GameObject[] stars;


    void Start()
    {
        // coinNum是数字，coinText.text是字符串
        ScoreText.text = SocreNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 倒计时
        Timer();
    }

    private void Timer()
    {
        if(isTimeOut == false)
        {
            // 减去每一帧的时间
            timer -= Time.deltaTime;
            // 更新显示的时间   ToString("F2")F2会保留两位小数，并且会对小数进行四舍五入
            timerText.text = "0" + timer.ToString("F2");

            // 如果倒计时小于等于0
            if(timer <= 0)
            {
                isTimeOut = true;
                timerText.text = "00:00";

                // 携程显示胜利面板
                StartCoroutine("ShowStarts");
            }
        }
    }

    // 显示胜利面板及根据coinNum显示星星
    IEnumerator ShowStarts()
    {
        winPanel.SetActive(true);

        if (SocreNum < 4)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            
        }
        else if(SocreNum < 6)
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
