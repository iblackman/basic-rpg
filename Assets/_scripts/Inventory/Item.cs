using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class Item {
    public enum ItemTypes { Weapon, Consumable}

    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    //button that has the action name
    public string ActionName { get; set; }
    //in case that item modify something
    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _stats, string _objectSlug, string _itemName ,string _description, ItemTypes _itemType, string _actionName, bool _itemModifier)
    {
        this.Stats = _stats;
        this.ObjectSlug = _objectSlug;
        this.ItemName = _itemName;
        this.Description = _description;
        this.ItemType = _itemType;
        this.ActionName = _actionName;
        this.ItemModifier = _itemModifier;
    }

    public string StatsToString()
    {
        string resp = "";
        if (Stats != null)
        {
            bool even = false;
            Stats.ForEach(delegate (BaseStat stat)
            {
                resp += stat ;
                if (even)
                {
                    resp += "\n";
                }
                else
                {
                    resp += "\t\t";
                }
                even = !even;
            });
        }
        return resp;
    }

    public override string ToString()
    {
        string resp = "";
        resp += "ObjectSlug = " + ObjectSlug + "\n";
        resp += "ItemName = " + ItemName + "\n";
        resp += "Description = " + Description + "\n";
        resp += "ActionName = " + ActionName + "\n";
        resp += "ItemModifier = " + ItemModifier + "\n";
        if (Stats != null)
        {
            resp += "Stats => \n";
            Stats.ForEach(delegate (BaseStat stat)
            {
                resp += "\t" + stat + "\n";
            });
        }
        return resp;
    }
}
