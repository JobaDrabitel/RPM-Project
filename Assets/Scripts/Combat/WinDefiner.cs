
public class WinDefiner
{
   
   public bool BattleEndCheck(Unit[] playerUnits, Unit[] enemyUnits)
    {
        int deadEnemyUnits = 0;
        int deadPlayerUnits = 0;
        for (int i = 0; i < 8; i++)
        {
            if (playerUnits[i].State == Unit.StateMachine.DEAD)
                deadPlayerUnits++;
            if (enemyUnits[i].State == Unit.StateMachine.DEAD)
                deadEnemyUnits++;
        }
        if (deadEnemyUnits == 4 || deadPlayerUnits == 4)
            return true;
        else 
            return false;
                
    }
}

