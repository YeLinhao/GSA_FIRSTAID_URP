using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 如果需要 UI 显示
public class QTE : MonoBehaviour
{
    // 定义目标序列（WASD 控制）
    private KeyCode[] targetSequence = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow };
    private int currentStep = 0; // 当前玩家的进度
    public Text messageText; // 显示消息的 UI 文本

    void Update()
    {
        // 检测玩家输入
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(targetSequence[currentStep]))
            {
                currentStep++; // 进度前进
                if (currentStep == targetSequence.Length)
                {
                    // 当完成整个序列时，显示完成消息
                    CompleteTask();
                }
            }
            else if (IsDirectionKeyPressed()) // 如果按错键，则重置
            {
                ResetSequence();
            }
        }
    }

    // 检查是否按下方向键
    private bool IsDirectionKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.UpArrow) ||
               Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.LeftArrow) ||
               Input.GetKeyDown(KeyCode.RightArrow);
    }

    // 完成任务时调用
    private void CompleteTask()
    {
        if (messageText != null)
        {
            messageText.text = "完成任务！";
        }
        Debug.Log("完成任务！");
        currentStep = 0; // 可根据需求重置或锁定
    }

    // 重置输入序列
    private void ResetSequence()
    {
        currentStep = 0;
        Debug.Log("输入错误，重置！");
    }


}
