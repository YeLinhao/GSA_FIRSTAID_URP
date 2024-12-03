using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    public Animator ambulanceAnimator;
    public string animationName = "AmbulanceAnimation";
    public GameObject GameTime;

    private bool animationStarted = false;

    void Start()
    {
        if (ambulanceAnimator == null)
        {
            ambulanceAnimator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (ambulanceAnimator != null && ambulanceAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            if (!animationStarted)
            {
                animationStarted = true;
                //GameTime.SetActive(false);
                Invoke(nameof(HideNPCs), 1f);
            }
        }
    }


    void HideNPCs()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject npc in npcs)
        {
            npc.SetActive(false);
        }
    }
  
}

