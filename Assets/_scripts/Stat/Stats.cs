using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {
    public enum Ref{atk,def,vit,agi}

    static readonly string[,] StatsMap = new string[,]{
        {"Attack", "It influences the amount of damage that you deal."},
        {"Defense", "It influences the amount of damage that you block."},
        {"Vitality", "It influences the amount of health."},
        {"Agility", "It influences your speed, critical chance and evade chance."}
    };

    //ATTACK
    public static string getAtkName()
    {
        return StatsMap[(int)Ref.atk,0];
    }
    public static string getAtkDescription()
    {
        return StatsMap[(int)Ref.atk,1];
    }

    public static BaseStat getAtkBaseStat(int value)
    {
        return new BaseStat(value, getAtkName(), getAtkDescription());
    }

    //DEFENSE
    public static string getDefName()
    {
        return StatsMap[(int)Ref.def,0];
    }
    public static string getDefDescription()
    {
        return StatsMap[(int)Ref.def,1];
    }

    public static BaseStat getDefBaseStat(int value)
    {
        return new BaseStat(value, getDefName(), getDefDescription());
    }

    //VITALITY
    public static string getVitName()
    {
        return StatsMap[(int)Ref.vit,0];
    }
    public static string getVitDescription()
    {
        return StatsMap[(int)Ref.vit,1];
    }

    public static BaseStat getVitBaseStat(int value)
    {
        return new BaseStat(value, getVitName(), getVitDescription());
    }

    //AGILITY
    public static string getAgiName()
    {
        return StatsMap[(int)Ref.agi,0];
    }
    public static string getAgiDescription()
    {
        return StatsMap[(int)Ref.agi,1];
    }

    public static BaseStat getAgiBaseStat(int value)
    {
        return new BaseStat(value, getAgiName(), getAgiDescription());
    } 
}
