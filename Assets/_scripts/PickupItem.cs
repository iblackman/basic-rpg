using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public Item item;

    public override void Interact()
    {
        Debug.Log("Interacting with PickupItem");
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up " + item.ItemName);
        //add item to inventory
        //InventoryController.Instance.AddItem();
        Destroy(gameObject);
    }
}
