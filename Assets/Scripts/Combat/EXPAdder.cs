using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPAdder
{
    private int totalEXP = 0;
    public int SetTotalEXP(Unit[] winUnits, Unit[] loserUnits)
    {
 
        for (int i = 0; i < winUnits.Length; i++)
        {
            winUnits[i].AddExp(totalEXP);
        }
        return totalEXP;
    }
    public void EXPCounter(Unit deadUnit)
    {
        totalEXP += deadUnit.EXPForKill;
    }
 
}