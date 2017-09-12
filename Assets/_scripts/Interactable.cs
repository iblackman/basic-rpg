using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    private NavMeshAgent playerAgent;
    private bool hasInteracted;

    public string DialogueName;
    public string[] dialogue;

    public float stopDistanceMultiplier = 4;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = stopDistanceMultiplier * playerAgent.GetComponent<NavMeshAgent>().radius;
        playerAgent.destination = this.transform.position;
    }

    public void Update()
    {
        if (playerAgent != null && !playerAgent.pathPending && !hasInteracted)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {   
                DialogueSystem.Instance.AddNewDialogue(dialogue, DialogueName);
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
