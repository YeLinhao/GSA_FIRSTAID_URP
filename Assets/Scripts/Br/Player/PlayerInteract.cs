using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Entity entity;
    public NPC npc;
    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            NPCController.Instance.SavingHint.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            NPCController.Instance.SavingHint.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            npc.Interact();
        }
    }

    public Entity GetInteractableEntity()
    {
        List<Entity> entitiesInteractable = new List<Entity>();
        Collider[] colliderAvalible = Physics.OverlapSphere(entity.collCenter.position, entity.InteractRange);
        foreach (Collider collider in colliderAvalible)
        {
            if (collider.TryGetComponent(out Entity entityInteractable))
            {
                entitiesInteractable.Add(entityInteractable);
            }
        }

        Entity closestEntityInteractable = null;
        foreach(Entity entityInteractable in entitiesInteractable)
        {
            if (closestEntityInteractable == null)
            {
                closestEntityInteractable= entityInteractable;
            }
            else
            {
                if(Vector3.Distance(transform.position, entityInteractable.transform.position) 
                    < Vector3.Distance(transform.position, closestEntityInteractable.transform.position)){

                }
            }
        }

        return closestEntityInteractable;
    }
}
