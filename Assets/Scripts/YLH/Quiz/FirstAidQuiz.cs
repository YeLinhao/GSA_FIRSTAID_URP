using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FirstAidQuiz: MonoBehaviour
{
    // List of images for options
    public QuizSpriteSO quizSpritePool;

    public List<Button> optionBtn;
    // The 4 positions in the first aid order
    public List<Sprite> randomizedOptionSprites;

    public List<Button> AnswerSlots;
    public List<Sprite> CorrectAnswer;

    public int TempAnsNum = 0;
   
    void Start()
    {
        SetupQuiz();
    }

    // Function to randomize the options and display them
    void SetupQuiz()
    {
        randomizedOptionSprites.Clear();
        AddCorrectOptions(randomizedOptionSprites,CorrectAnswer);
        AddRandomWrongAnswer(randomizedOptionSprites,quizSpritePool,optionBtn.Count-AnswerSlots.Count);
        ShuffleList(randomizedOptionSprites);

        //Apply randomized sprite to Btn.
        for (int i = 0; i < 6; i++)
        {
            optionBtn[i].GetComponent<Image>().sprite = randomizedOptionSprites[i];
        }
    }

    //Add Correct Answer for THIS TYPE OF FIRST AID
    void AddCorrectOptions(List<Sprite>list, List<Sprite>CorrectList)
    {
        for (int i = 0; i < CorrectList.Count; i++)
        {
            list.Add(CorrectList[i]);
        }
    }

    void AddRandomWrongAnswer(List<Sprite> list, QuizSpriteSO Spritepool, int addNums)
    {
        //To guarantee won't add correct num
        List<Sprite> candidates = Spritepool.QuizSprites.Except(list).ToList();
        for(int i = 0; i < addNums; i++)
        {
            int j = Random.Range(0, candidates.Count);
            list.Add(candidates[j]);
            candidates.RemoveAt(j);//guarantee next add won't be same again
        }

    }

    // Shuffle a list of sprites (Fisher-Yates shuffle)
    void ShuffleList(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int j = Random.Range(i, list.Count); // Random index
            Sprite temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void CheckAnswer()
    {
        bool isCorrect = true;

        // Loop through the correct order slots and compare with the selected images
        for (int i = 0; i < AnswerSlots.Count; i++)
        {
            if (AnswerSlots[i].GetComponent<Image>().sprite != CorrectAnswer[i]) // Check if the image in the slot is correct
            {
                isCorrect = false;
                break; 
            }
        }

        if (isCorrect)
        {
            Debug.Log("Correct! You completed the first aid sequence.");
            ScoreManager.Instance.score++;
            this.gameObject.SetActive(false);
            // Reset Image in AnswerSlots
            foreach ( Button btn in AnswerSlots)
            {
                btn.GetComponent<Image>().sprite = null;
                btn.interactable = false;
                TempAnsNum--;
            }
            //Reset Random Options
            SetupQuiz();
            
        }
        else
        {
            Debug.Log("Incorrect! Please try again.");
        }
    }

    // This function should be connected to UI events where players can drag and drop or select images.
    public void OnOptionSelected(int BtnID)
    {
        //Add sprite you clicked to the first empty slot
        for (int i = 0; i < AnswerSlots.Count; i++)
        {
            if (AnswerSlots[i].interactable == false)
            {
                AnswerSlots[i].GetComponent<Image>().sprite = optionBtn[BtnID].GetComponent<Image>().sprite;
                //allow to be canceled
                AnswerSlots[i].interactable = true;
                break;
            }
        }
        TempAnsNum++;

        // Once the player has placed images in all the slots, check if the answer is correct
        if (TempAnsNum == AnswerSlots.Count)
        {
            CheckAnswer();
        }
    }

    public void OnAnswerCanceled(int AnswerSlotID) 
    {
        AnswerSlots[AnswerSlotID].GetComponent<Image>().sprite = null;
        AnswerSlots[AnswerSlotID].interactable = false;
        TempAnsNum--;
    }


}
