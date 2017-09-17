using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    //button that has the action name
    public string ActionName { get; set; }
    //in case that item modify something
    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
    }

    public Item(List<BaseStat> _stats, string _objectSlug, string _itemName ,string _description, string _actionName, bool _itemModifier)
    {
        this.Stats = _stats;
        this.ObjectSlug = _objectSlug;
        this.ItemName = _itemName;
        this.Description = _description;
        this.ActionName = _actionName;
        this.ItemModifier = _itemModifier;
    }

}
