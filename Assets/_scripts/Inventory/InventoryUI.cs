using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    InventoryUIItem ItemContainer { get; set; }
    Item SelectedItem { get; set; }

    // Use this for initialization
    void Start () {
        ItemContainer = Resources.Load<InventoryUIItem>("ui/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {   
            inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
        }
    }

    void ItemAdded(Item _item)
    {
        InventoryUIItem emptyItem = Instantiate(ItemContainer);
        emptyItem.SetItem(_item);
        emptyItem.transform.SetParent(scrollViewContent);
        //UpdateScrollViewHeight();
    }

    void UpdateScrollViewHeight()
    {
        int numChilds = scrollViewContent.childCount;
        scrollViewContent.sizeDelta = new Vector2(0, 40 * numChilds);
    }
}
