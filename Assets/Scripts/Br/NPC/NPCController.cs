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
        while (npcs.Count > 0)
        {
            int randomIndex = Random.Range(0, npcs.Count);
            NPC sickNpc = npcs[randomIndex];

            sickNpc.isShocked = true;
            Debug.Log("NPC is shocked");

            npcs.RemoveAt(randomIndex);

            yield return new WaitForSeconds(10f);
        }

        Debug.Log("All shocked");
    }
}
