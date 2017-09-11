using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    private NavMeshAgent playerAgent;

    public float stopDistanceMultiplier = 4;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = stopDistanceMultiplier * playerAgent.GetComponent<NavMeshAgent>().radius;
        playerAgent.destination = this.transform.position;

        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
