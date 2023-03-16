using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArraysPrepare 
{
    public Unit[] ArrayByInitiativeSort(Unit[] units)
    {
        Unit[] sortedUnits = new Unit[8];
        for (int i = 0; i < 8; i++)
            sortedUnits[i] = units[i];
        Unit temp;
        for (int write = 0; write < sortedUnits.Length; write++)
        {
            for (int sort = 0; sort < sortedUnits.Length - 1; sort++)
            {
                if (sortedUnits[sort].SetRandomInitiative() < sortedUnits[sort + 1].SetRandomInitiative())
                {
                    temp = sortedUnits[sort + 1];
                    sortedUnits[sort + 1] = sortedUnits[sort];
                    sortedUnits[sort] = temp;
                }
            }
        }
        return sortedUnits;
    }
    public Unit[] SetUnitsBySide(Unit[] units, bool IsPlayer)
    {
        Unit[] unitsBySide = new Unit[4];
        int j = IsPlayer ? 0 : 4;
        for (int i = 0; i<4; i++, j++)
        {
            unitsBySide[i] = units[j];
        }
        return unitsBySide;
    }
}
