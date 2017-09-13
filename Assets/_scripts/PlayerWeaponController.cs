using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;

    public GameObject EquippedWeapon { get; set; }

    private IWeapon IWEquipped;
    private CharacterStat characterStat;

    void Start()
    {
        characterStat = GetComponent<CharacterStat>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        //check if there is already a weapon equipped
        if (EquippedWeapon != null) 
        {
            characterStat.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);    
        }
        EquippedWeapon = Instantiate<GameObject>(Resources.Load<GameObject>("weapons/" + itemToEquip.ObjectSlug), 
            playerHand.transform.position, playerHand.transform.rotation);
        //gets IWeapon from GameObject EquippedWeapon
        IWEquipped = EquippedWeapon.GetComponent<IWeapon>();
        //Atributes stats to IWeapon
        IWEquipped.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStat.AddStatBonus(itemToEquip.Stats);
    }

    public void PerformWeaponAttack()
    {
        IWEquipped.PerformAttack();
    }
	
}
