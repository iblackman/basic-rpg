using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {

    CharacterStat stats;

    // Use this for initialization
    void Start() {
        stats = GetComponent<Player>().characterStat;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate<GameObject>(Resources.Load<GameObject>("consumables/"+item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
        //destroy consumable item after its use
        Destroy(itemToSpawn);
    }
}
