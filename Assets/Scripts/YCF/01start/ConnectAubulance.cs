using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectAubulance : MonoBehaviour

{
    [Header("Timer Settings")]
    public float gameTime = 60f; // 总倒计时时间（秒）
    public Text timerText; // 显示倒计时的UI文本

    [Header("Ambulance Settings")]
    public Animator ambulanceAnimator; // 救护车的Animator组件
    public string ambulanceAnimationTrigger = "Activate"; // 动画触发器名称

    private float currentTime; // 当前剩余时间
    private bool isTimerRunning = false; // 倒计时是否运行中

    private void Start()
    {
        // 初始化时间并开始倒计时
        currentTime = gameTime;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (currentTime > 0)
            {
                // 更新倒计时
                currentTime -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                // 倒计时结束
                currentTime = 0;
                isTimerRunning = false;
                TriggerAmbulanceAnimation();
            }
        }
    }

    // 更新倒计时UI文本
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    // 激活救护车动画
    private void TriggerAmbulanceAnimation()
    {
        if (ambulanceAnimator != null)
        {
            ambulanceAnimator.SetTrigger(ambulanceAnimationTrigger);
        }
        else
        {
            Debug.LogError("Ambulance Animator is not assigned!");
        }
    }
}

