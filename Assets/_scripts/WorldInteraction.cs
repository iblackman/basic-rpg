using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        //hide dialogueSystem if there is a new Interation
        DialogueSystem.Instance.dialoguePanel.SetActive(false);

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactObject = interactionInfo.collider.gameObject;
            if(interactObject.tag == "Enemy")
            {
                Debug.Log("Interacting with Enemy");
                interactObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else if (interactObject.tag == "InteractableObject")
            {
                interactObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
