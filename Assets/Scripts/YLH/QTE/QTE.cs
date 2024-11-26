using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    //public bool isOn = false;
    public List<KeyCode> keyCodeSequence = new List<KeyCode>();
    public QTEVisualizer visualizer;

    private int currentIndex = 0;

    // QTE Task
    public void StartTask()
    {
        //Initialize
        visualizer.VisualizeKeySequence(keyCodeSequence);
        currentIndex = 0;
        Debug.Log("Mission Start!Press key in Sequence.");
    }

    void Update()
    {

        // Check key just be pressed 
        if (keyCodeSequence != null)
        {
            if (Input.anyKeyDown)
            {
                //if input Correct
                if (Input.GetKeyDown(keyCodeSequence[currentIndex]))
                {
                    Debug.Log("Correct one! " + keyCodeSequence[currentIndex].ToString());
                    currentIndex++; // Move on


                    if (currentIndex == keyCodeSequence.Count)
                    {
                        CompleteTask();
                    }
                }
                //Not Correct
                else
                {
                    StartTask();
                    Debug.Log("Error! please Refresh!");
                }
            }
        }

    }
    private void CompleteTask()
    {
        Debug.Log("Mission Complete!");
        currentIndex = 0;
    }
}
















