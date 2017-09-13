using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {

    public List<BaseStat> stats = new List<BaseStat>();

    public int atk;
    public int def;
    public int vit;
    public int agi;

    void Start()
    {
        stats.Add(Stats.getAtkBaseStat(atk));
        stats.Add(Stats.getDefBaseStat(def));
        stats.Add(Stats.getVitBaseStat(vit));
        stats.Add(Stats.getAgiBaseStat(agi));
        //stats["atk"].AddStatBonus(new StatBonus(1));
        Debug.Log(stats.Find(x => x.StatName == Stats.getAtkName()));
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (var statB in statBonuses)
        {
            stats.Find(x => x.StatName == statB.StatName).AddStatBonus(new StatBonus(statB.CalculateStatFinalValue()));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (var statB in statBonuses)
        {
            stats.Find(x => x.StatName == statB.StatName).RemoveStatBonus(new StatBonus(statB.CalculateStatFinalValue()));
        }
    }
}
