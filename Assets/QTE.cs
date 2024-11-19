using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �����Ҫ UI ��ʾ
public class QTE : MonoBehaviour
{
    // ����Ŀ�����У�WASD ���ƣ�
    private KeyCode[] targetSequence = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow };
    private int currentStep = 0; // ��ǰ��ҵĽ���
    public Text messageText; // ��ʾ��Ϣ�� UI �ı�

    void Update()
    {
        // ����������
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(targetSequence[currentStep]))
            {
                currentStep++; // ����ǰ��
                if (currentStep == targetSequence.Length)
                {
                    // �������������ʱ����ʾ�����Ϣ
                    CompleteTask();
                }
            }
            else if (IsDirectionKeyPressed()) // ����������������
            {
                ResetSequence();
            }
        }
    }

    // ����Ƿ��·����
    private bool IsDirectionKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.UpArrow) ||
               Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.LeftArrow) ||
               Input.GetKeyDown(KeyCode.RightArrow);
    }

    // �������ʱ����
    private void CompleteTask()
    {
        if (messageText != null)
        {
            messageText.text = "�������";
        }
        Debug.Log("�������");
        currentStep = 0; // �ɸ����������û�����
    }

    // ������������
    private void ResetSequence()
    {
        currentStep = 0;
        Debug.Log("����������ã�");
    }


}
