using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
    public static ItemDatabase Instance { get; set; }
                                      
    private List<Item> Items { get; set; }

    void Awake () {
		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();
	}

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("json/Items").ToString());
        Items.ForEach(delegate (Item item) {
            Debug.Log(item);
        });

    }
    //returns the item with the same ObjectSlug, if there is no such item it returns null
    public Item GetItem(string _itemSlug)
    {
        return Items.Find(x => x.ObjectSlug == _itemSlug);
    }
}
