using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat {

    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStat(int _attack, int _defense, int _vitality, int _agility)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.StatTypes.Attack, _attack, BaseStat.StatTypes.Attack.ToString()),
            new BaseStat(BaseStat.StatTypes.Defense, _attack, BaseStat.StatTypes.Defense.ToString()),
            new BaseStat(BaseStat.StatTypes.Vitality, _attack, BaseStat.StatTypes.Vitality.ToString()),
            new BaseStat(BaseStat.StatTypes.Agility, _attack, BaseStat.StatTypes.Agility.ToString()),
        };
    }

    public BaseStat GetStat(BaseStat.StatTypes _statType)
    {
        return this.stats.Find(x => x.StatType == _statType);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (var statB in statBonuses)
        {
            GetStat(statB.StatType).AddStatBonus(new StatBonus(statB.CalculateStatFinalValue()));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (var statB in statBonuses)
        {
            GetStat(statB.StatType).RemoveStatBonus(new StatBonus(statB.CalculateStatFinalValue()));
        }
    }
    
    public float GetHealth()
    {
        int aux = GetStat(BaseStat.StatTypes.Vitality).CalculateStatFinalValue();
        return aux * Constants.HEALTH_MULTIPLIER;
    }

    public int GetDamage()
    {
        return GetStat(BaseStat.StatTypes.Attack).CalculateStatFinalValue();
    }
}

