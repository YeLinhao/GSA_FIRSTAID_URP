using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectAubulance : MonoBehaviour

{
    [Header("Timer Settings")]
    public float gameTime = 60f; // �ܵ���ʱʱ�䣨�룩
    public Text timerText; // ��ʾ����ʱ��UI�ı�

    [Header("Ambulance Settings")]
    public Animator ambulanceAnimator; // �Ȼ�����Animator���
    public string ambulanceAnimationTrigger = "Activate"; // ��������������

    private float currentTime; // ��ǰʣ��ʱ��
    private bool isTimerRunning = false; // ����ʱ�Ƿ�������

    private void Start()
    {
        // ��ʼ��ʱ�䲢��ʼ����ʱ
        currentTime = gameTime;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (currentTime > 0)
            {
                // ���µ���ʱ
                currentTime -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                // ����ʱ����
                currentTime = 0;
                isTimerRunning = false;
                TriggerAmbulanceAnimation();
            }
        }
    }

    // ���µ���ʱUI�ı�
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    // ����Ȼ�������
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

