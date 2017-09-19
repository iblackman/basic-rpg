using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour {
    public Item item;

    public Text itemName;
    public Image itemIcon;

    public void SetItem(Item _item)
    {
        this.item = _item;
        itemName = this.transform.Find("Item_Name").GetComponent<Text>();
        itemIcon = this.transform.Find("Item_Icon").GetComponent<Image>();
        SetupItemValues();
    }

    public void SetupItemValues()
    {
        itemName.text = item.ItemName;
        itemIcon.sprite = Resources.Load<Sprite>("ui/icons/itens/"+ item.ObjectSlug);
    }
	
    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
