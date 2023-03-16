using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChoice : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private BattleController battleController;
    public int Number { get => number; }
    public void OnTargetChoiceClick()
    {
        number = gameObject.GetComponent<TargetChoice>().number;
        battleController.GetTarget(Number);
    }
}
