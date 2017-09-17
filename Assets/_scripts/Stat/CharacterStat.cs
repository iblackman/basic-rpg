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
        stats.Add(StatsRef.GetAtkBaseStat(atk));
        stats.Add(StatsRef.GetDefBaseStat(def));
        stats.Add(StatsRef.GetVitBaseStat(vit));
        stats.Add(StatsRef.GetAgiBaseStat(agi));
        //stats["atk"].AddStatBonus(new StatBonus(1));
        Debug.Log(stats.Find(x => x.StatName == StatsRef.GetAtkName()) + "\n" + stats.Find(x => x.StatName == StatsRef.GetVitName()));
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

    public float GetHealth()
    {
        Debug.Log("gethealth => "+ stats.Find(x => x.StatName == StatsRef.GetVitName()));
        int aux = stats.Find(x => x.StatName == StatsRef.GetVitName()).CalculateStatFinalValue();
        return aux * 10f;
    }
}
