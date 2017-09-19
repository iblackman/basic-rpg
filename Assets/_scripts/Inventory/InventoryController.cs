using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryDetailsPanel;

    public List<Item> InventoryItems = new List<Item>();

    void Start()
    {
        //singleton pattern
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        AddItem("Sword_Basic");
        AddItem("Staff_Basic");
        AddItem("Potion_Health");
    }

    public void AddItem(string _itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(_itemSlug);
        InventoryItems.Add(item);
        Debug.Log(item);
        UIEventHandler.ItemAddedToInventory(item);
        Debug.Log("New item added to inventory.\n" + ItemDatabase.Instance.GetItem(_itemSlug));
    }

    public void SetItemDetails(Item _item, Button _button)
    {
        inventoryDetailsPanel.SetItem(_item, _button);
    }
    public void EquipItem(Item _itemToEquip)
    {
        playerWeaponController.EquipWeapon(_itemToEquip);
    }

    public void ConsumeItem(Item _itemToConsume)
    {
        consumableController.ConsumeItem(_itemToConsume);
    }
}
