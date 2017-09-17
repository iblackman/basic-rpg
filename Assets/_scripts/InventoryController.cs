using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public Item sword;
    public Item staff;
    public Item potionHealth;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(StatsRef.GetAtkBaseStat(2));
        sword = new Item(swordStats, "Basic_Sword");

        staff = new Item(swordStats, "Basic_Staff");

        potionHealth = new Item(new List<BaseStat>(), "Potion_Health", "Health Potion", "Drink to recover health", "Use", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerWeaponController.EquipWeapon(staff);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            consumableController.ConsumeItem(potionHealth);
        }
    }
}
