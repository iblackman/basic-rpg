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
        //need to check if there is a playerAgent before checking its stoppingDistance
        if (playerAgent)
        {
            //if player interacts with something before reaching destination, cancel interaction
            //I did this because it was accumulating interactions, and it only showed the first one, not the last.
            if (playerAgent.stoppingDistance == 0f)
            {
                hasInteracted = true;
            }
        }
        

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
