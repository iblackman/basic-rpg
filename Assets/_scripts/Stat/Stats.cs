using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsRef {
    public enum Ref{atk,def,vit,agi}

    static readonly string[,] StatsMap = new string[,]{
        {"Attack", "It influences the amount of damage that you deal."},
        {"Defense", "It influences the amount of damage that you block."},
        {"Vitality", "It influences the amount of health."},
        {"Agility", "It influences your speed, critical chance and evade chance."}
    };

    //ATTACK
    public static string GetAtkName()
    {
        return StatsMap[(int)Ref.atk,0];
    }
    public static string GetAtkDescription()
    {
        return StatsMap[(int)Ref.atk,1];
    }

    public static BaseStat GetAtkBaseStat(int value)
    {
        return new BaseStat(value, GetAtkName(), GetAtkDescription());
    }

    //DEFENSE
    public static string GetDefName()
    {
        return StatsMap[(int)Ref.def,0];
    }
    public static string GetDefDescription()
    {
        return StatsMap[(int)Ref.def,1];
    }

    public static BaseStat GetDefBaseStat(int value)
    {
        return new BaseStat(value, GetDefName(), GetDefDescription());
    }

    //VITALITY
    public static string GetVitName()
    {
        return StatsMap[(int)Ref.vit,0];
    }
    public static string GetVitDescription()
    {
        return StatsMap[(int)Ref.vit,1];
    }

    public static BaseStat GetVitBaseStat(int value)
    {
        return new BaseStat(value, GetVitName(), GetVitDescription());
    }

    //AGILITY
    public static string GetAgiName()
    {
        return StatsMap[(int)Ref.agi,0];
    }
    public static string GetAgiDescription()
    {
        return StatsMap[(int)Ref.agi,1];
    }

    public static BaseStat GetAgiBaseStat(int value)
    {
        return new BaseStat(value, GetAgiName(), GetAgiDescription());
    } 
}
