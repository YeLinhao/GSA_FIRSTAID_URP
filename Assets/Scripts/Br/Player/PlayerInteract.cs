using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Entity entity;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliderAvalible = Physics.OverlapSphere(entity.collCenter.position, entity.InteractRange);
            foreach (Collider collider in colliderAvalible)
            {
                if(collider.TryGetComponent(out Entity entity))
                {
                    entity.Interact();
                }
            }
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
