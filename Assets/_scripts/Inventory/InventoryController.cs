using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    #region Singleton
    public static InventoryController Instance { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryDetailsPanel;

    public List<Item> InventoryItems = new List<Item>();
    public int space = 20;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        AddItem("Sword_Basic");
        AddItem("Staff_Basic");
        AddItem("Potion_Health");
    }

    public bool AddItem(string _itemSlug)
    {
        if(InventoryItems.Count < space)
        {
            Item item = ItemDatabase.Instance.GetItem(_itemSlug);
            InventoryItems.Add(item);
            Debug.Log(item);
            UIEventHandler.ItemAddedToInventory(item);
            return true;
        }
        else
        {
            Debug.Log("Counldn't add item, inventory full.");
            return false;
        }
        
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
