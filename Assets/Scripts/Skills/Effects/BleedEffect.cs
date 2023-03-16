using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : MonoBehaviour, IEffect
{
    private int _duration = 3;
    private int _currentDuration = 3;

    public int Duration => _duration;

    public int CurrentDuration => _currentDuration;

    public void Effect(Unit target)
    {
        if (target.State == Unit.StateMachine.TURN)
        {
            target.TakeDamage(target.CurrentHP/10);
        }
    }

    public void CurrentDurationDecrease()
    {
        _currentDuration--;
    }
    public void CurrentDurationSet()
    {
        _currentDuration = _duration;
    }
}
