using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public List<NPC> npcs;

    public void Start()
    {
        npcs = new List<NPC>(FindObjectsOfType<NPC>());
        StartCoroutine(whoIsSick());
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
