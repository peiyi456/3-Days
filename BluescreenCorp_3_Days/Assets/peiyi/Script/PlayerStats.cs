using System;
using System.Collections.Generic;

public class PlayerStats
{
    public float BaseValue;

    public float Value
    {
        get
        {
            if (isDirty)
            {
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    private bool isDirty = true;
    private float _value;

    private readonly List<StatsModifier> statsModifiers;

    public PlayerStats(float baseValue)
    {
        BaseValue = baseValue;
        statsModifiers = new List<StatsModifier>();
    }

    public void AddModifier(StatsModifier mod)
    {
        isDirty = true;
        statsModifiers.Add(mod);
        statsModifiers.Sort(CompareModifierOrder);
    }

    private int CompareModifierOrder(StatsModifier a, StatsModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0; //if(a.Order == b.Order)
    }

    public bool RemoveModifier(StatsModifier mod)
    {
        isDirty = true;
        return statsModifiers.Remove(mod);
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;

        for(int i = 0; i < statsModifiers.Count; i++)
        {
            StatsModifier mod = statsModifiers[i];

            if(mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }

            else if(mod.Type == StatModType.Percent)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        //12.0001f != 12f
        return (float)Math.Round(finalValue, 4);    
    }
}
