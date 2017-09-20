using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;

    public GameObject EquippedWeapon { get; set; }

    Transform projectileSpawn;
    private IWeapon IWEquipped;
    private CharacterStat characterStat;

    void Start()
    {
        projectileSpawn = transform.Find("ProjectileSpawn");
        characterStat = GetComponent<Player>().characterStat;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        //check if there is already a weapon equipped
        if (EquippedWeapon != null) 
        {
            MoveWeaponToInventory();
        }
        EquippedWeapon = Instantiate<GameObject>(Resources.Load<GameObject>("weapons/" + itemToEquip.ObjectSlug), 
            playerHand.transform.position, playerHand.transform.rotation, playerHand.transform);
        //gets IWeapon from GameObject EquippedWeapon
        IWEquipped = EquippedWeapon.GetComponent<IWeapon>();

        //check if this weapon is a projectile weapon
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = projectileSpawn;
        }

        //Atributes stats to IWeapon
        IWEquipped.Stats = itemToEquip.Stats;
        //EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStat.AddStatBonus(itemToEquip.Stats);
    }

    void MoveWeaponToInventory()
    {
        //remove stat bonus
        characterStat.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
        //get weapon object
        GameObject objectEquipped = playerHand.transform.GetChild(0).gameObject;
        //destroy object from hand
        Destroy(objectEquipped);
        //add same item in inventory (passing the name of the object removing the string '(Clone)'
        InventoryController.Instance.AddItem(objectEquipped.name.Replace("(Clone)", ""));
    }

    public void Update()
    {
        //check in order to doesnt attack without an element
        if (EquippedWeapon)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                PerformWeaponBasicAttack();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                PerformWeaponSecondaryAttack();
            }
        }
        
    }

    public void PerformWeaponBasicAttack()
    {
        IWEquipped.PerformBasicAttack();
    }

    public void PerformWeaponSecondaryAttack()
    {
        IWEquipped.PerformSecondaryAttack();
    }

}
