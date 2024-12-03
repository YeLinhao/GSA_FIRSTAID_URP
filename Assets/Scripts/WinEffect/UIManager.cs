using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // ����ʱ�� [SerializeField]���Խ�private���͵ı�����unity�������ʾ
    [SerializeField] private float timer = 60f;
    // �������
    [SerializeField] private float SocreNum = 0f;

    // ��ʾʱ��ͽ������Text���
    public Text timerText;
    public Text ScoreText;


    private bool isTimeOut = false;


    public GameObject winPanel;
   
    public GameObject[] stars;


    void Start()
    {
        // coinNum�����֣�coinText.text���ַ���
        ScoreText.text = SocreNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // ����ʱ
        Timer();
    }

    private void Timer()
    {
        if(isTimeOut == false)
        {
            // ��ȥÿһ֡��ʱ��
            timer -= Time.deltaTime;
            // ������ʾ��ʱ��   ToString("F2")F2�ᱣ����λС�������һ��С��������������
            timerText.text = "0" + timer.ToString("F2");

            // �������ʱС�ڵ���0
            if(timer <= 0)
            {
                isTimeOut = true;
                timerText.text = "00:00";

                // Я����ʾʤ�����
                StartCoroutine("ShowStarts");
            }
        }
    }

    // ��ʾʤ����弰����coinNum��ʾ����
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
