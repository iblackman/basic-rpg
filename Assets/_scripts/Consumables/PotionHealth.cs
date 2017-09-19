using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("You drank a health postion.");
    }

    public void Consume(CharacterStat characterStat)
    {
        Debug.Log("You drank a health postion. With CharacterStats");
    }
}
