using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BattleFinisher : MonoBehaviour
{
    public UnityEvent BattleEndEvent;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas loseCanvas;
    public void FinishBattle(bool isPlayerWon)
    {
        if (isPlayerWon)
        {
            Debug.Log("Поздравляем с победой");
            winCanvas.gameObject.SetActive(true);
           
        }
        else
        {
            Debug.Log("Помянем...");
            loseCanvas.gameObject.SetActive(true);
        }
    }
    public void BattleEndCheck(Unit[] playerUnits, Unit[] enemyUnits)
    {
        WinDefiner winDefiner = new WinDefiner();
        if (winDefiner.BattleEndCheck(playerUnits, enemyUnits))
        {
            BattleEndEvent.Invoke();
        }
    }
}
