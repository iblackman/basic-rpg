using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, DialogueName);
        Debug.Log("Interacting with NPC.");
    }
}
