using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    private NavMeshAgent playerAgent;
    private bool hasInteracted;
    private bool isEnemy;

    public string DialogueName;
    public string[] dialogue;

    public float stopDistanceMultiplier = 4;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";
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
                if (!isEnemy)
                {
                    DialogueSystem.Instance.AddNewDialogue(dialogue, DialogueName);
                    Interact();
                }
                EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    public void EnsureLookDirection()
    {
        //disable the automatic rotation, navAgent doesnt control the rotation when it is false
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        //enable automatic rotation
        playerAgent.updateRotation = true;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
