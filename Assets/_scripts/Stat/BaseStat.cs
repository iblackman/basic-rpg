using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {
    public List<StatBonus> BonusList { get; set; }

    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BonusList = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(int baseValue, string statName)
    {
        this.BonusList = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BonusList.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        //this code removes the first statBonus with the equal value, not necessarily the stat bonus passed 
        //(better performance maybe)
        //PS: it can be a problem or not:
          //  Because it will remove the first value that matches the statBonus passed value, if using the other code
          //  it would only remove if the statBonus passed is in the bonusList, otherwise wouldnt change the bonusList at all
        this.BonusList.Remove(BonusList.Find(x => x.BonusValue == statBonus.BonusValue));
        //this.BonusList.Remove(statBonus);
    }

    public int CalculateStatFinalValue()
    {
        this.FinalValue = this.BaseValue;
        this.FinalValue += CaculateBonusValue();
        //in case bonus value is negative, final value should not be less than 0
        if (this.FinalValue < 0)
        {
            this.FinalValue = 0;
        }
        return this.FinalValue;
    }
    //calculate de stat bonus amout
    public int CaculateBonusValue()
    {
        int totalBonus = 0;
        this.BonusList.ForEach(x => totalBonus += x.BonusValue);
        return totalBonus;
    }

    public override string ToString()
    {
        return StatName +": " + CalculateStatFinalValue();
    }
  }
