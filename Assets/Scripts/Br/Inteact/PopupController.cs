using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{

    public GameObject InteractButton;
    [SerializeField]private PlayerInteract playerInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInteract.GetInteractableEntity() != null){
        Show();
        }else{
        Hide();
        }
    }

        public void Show()
    {
       InteractButton.SetActive(true);
    }

    public void Hide()
    {
       InteractButton.SetActive(false);
    }
}
