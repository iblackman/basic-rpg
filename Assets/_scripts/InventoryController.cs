using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public PlayerWeaponController playerWeaponController;
    public Item sword;
    public Item staff;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(StatsRef.GetAtkBaseStat(2));
        sword = new Item(swordStats, "Basic_Sword");

        staff = new Item(swordStats, "Basic_Staff");
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
    }
}
