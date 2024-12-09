using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCController : MonoBehaviour
{
    public static NPCController Instance;


    public List<NPC> npcs;
    public NPC isBeingSaved;

    public List<GameObject> VideoList;
    public List<GameObject> QuizList;

    public TMP_Text SavingHint;

    void Awake()
    {
       Instance = this;
    }
    
    public void Start()
    {
        npcs = new List<NPC>(FindObjectsOfType<NPC>());
        StartCoroutine(whoIsSick());
        // Sick();
    }

    public void Sick(){
        NPC shocked = npcs[0];
        shocked.isShocked = true;
        NPC heated = npcs[1];

    }

    public IEnumerator whoIsSick()
    {
        if (GameManager.Instance.GameMode>0)
        {
            while (npcs.Count > 0)
            {
                int randomIndex = Random.Range(0, npcs.Count);
                NPC sickNpc = npcs[randomIndex];

                RandomSickAssign(sickNpc);
                Debug.Log(sickNpc.gameObject.name + "Random Sickness Assigned");
                npcs.RemoveAt(randomIndex);

                if ((GameManager.Instance.GameMode - 1) % 3 == 0)
                {
                    yield return new WaitForSeconds(10f);
                }
                if ((GameManager.Instance.GameMode + 1) % 3 == 0)
                {
                    yield return new WaitForSeconds(5f);
                }
                
            }

        }

    }

    /// <summary>
    /// Assign Sickness according to GameMode
    /// </summary>
    /// <param name="npcToSick"></param>
    public void RandomSickAssign(NPC npcToSick)
    {

        if (GameManager.Instance == null)
        {
            Debug.Log("Please Start with Beginning Scene");
        }
        else if (GameManager.Instance.GameMode == 1 || GameManager.Instance.GameMode == 2)//Factory Game
        {
            int randomIndex = Random.Range(0, 3);
            switch (randomIndex)
            {
                case 0:
                    npcToSick.isBleeding = true;
                    break;
                case 1:
                    npcToSick.isShocked = true;
                    break;
                case 2:
                    npcToSick.isHeatStroked = true;
                    break;

                default:
                    break;
            }
        }
        else if (GameManager.Instance.GameMode == 4 || GameManager.Instance.GameMode == 5)//Classroom Game
        {
            int randomIndex = Random.Range(0, 3);
            switch (randomIndex)
            {
                case 0:
                    npcToSick.isNoseBleeding = true;
                    break;
                case 1:
                    npcToSick.isAsthma = true;
                    break;
                case 2:
                    npcToSick.isConvulsiveSeizure = true;
                    break;

                default:
                    break;
            }
        }
        else if (GameManager.Instance.GameMode == 7 || GameManager.Instance.GameMode == 8)//Park Game
        {
            int randomIndex = Random.Range(0, 4);
            switch (randomIndex)
            {
                case 0:
                    npcToSick.isTwisted = true;
                    break;
                case 1:
                    npcToSick.isTickBited = true;
                    break;
                case 2:
                    npcToSick.isChoked = true;
                    break;
                case 3:
                    npcToSick.isDiabetic = true;
                    break;
                default:
                    break;
            }
     
        }


    }

    public void StartSavingVideo(int VideoType)
    {
        VideoList[VideoType].SetActive(true);
    }

    public void StartSavingQuiz(int QuizType)
    {
        QuizList[QuizType].SetActive(true);
    }


    public void NPCHealed()
    {
        isBeingSaved.BubbleVanish();
        isBeingSaved.NPCHealed();

    }


    public void ClearAllUIWhenFinished()
    {
        foreach(var quizobject in QuizList)
        {
            quizobject.GetComponent<FirstAidQuiz>().SetupQuiz();
            quizobject.SetActive(false);
        }
        SavingHint.gameObject.SetActive(false);

    }

    public void LockInputWhenFinished()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        
    }



    public bool Tutorial_CheckIfEveryoneHealed()
    {
        List<NPC> Checknpcs = new List<NPC>(FindObjectsOfType<NPC>());
        bool IfEveryoneHealed = true;

        foreach (var npc in Checknpcs)
        {
            if (npc.isHealed == false)
            {
                IfEveryoneHealed = false;
            }
        }

        return IfEveryoneHealed;
    }

}
