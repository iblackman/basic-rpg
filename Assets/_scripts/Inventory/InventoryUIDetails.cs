using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {

    public Item item;
    public Button selectedItemButton, actionButton;
    public Text itemNameText, itemDescriptionText, actionButtonText, itemStatsText;

    private void Start()
    {
        DisablePanel();
        itemNameText = this.transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText = this.transform.Find("Item_Description").GetComponent<Text>();
        itemStatsText = this.transform.Find("Item_Stats").GetComponentInChildren<Text>();
        actionButton = this.transform.Find("Button_Action").GetComponent<Button>();
        actionButtonText = actionButton.transform.Find("Text").GetComponent<Text>();
    }

    public void SetItem(Item _item, Button _selectedItemButton)
    {
        this.item = _item;
        this.selectedItemButton = _selectedItemButton;
        SetupItemValues();
    }

    public void SetupItemValues()
    {
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        actionButtonText.text = item.ActionName;
        itemStatsText.text = item.StatsToString();
        //remove all listerners first, otherwise it would stack a listener every time an item is clicked
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnActionButtonCLick);
        EnablePanel();
    }

    public void OnActionButtonCLick()
    {
        DisablePanel();
        if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
            //since it was equiped, it is not is the invetory anymore, should be destroyed
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            //since it was consumed, it is not is the invetory anymore, should be destroyed
            Destroy(selectedItemButton.gameObject);
        }
        
    }

    void EnablePanel()
    {
        this.gameObject.SetActive(true);
    }

    void DisablePanel()
    {
        this.gameObject.SetActive(false);
    }
}
