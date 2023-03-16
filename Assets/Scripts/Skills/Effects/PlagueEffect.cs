using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueEffect : MonoBehaviour, IEffect
{
    private int _duration = 3;
    private int _currentDuration = 3;

    public int Duration => _duration;

    public int CurrentDuration => _currentDuration;
    public void CurrentDurationDecrease()
    {
        _currentDuration--;
    }
    public void CurrentDurationSet()
    {
        _currentDuration = _duration;
    }

    public void Effect(Unit target)
    {
        if (target.MaxHP > 5)
        target.SetMaxHP(target.MaxHP - 5);
        target.TakeDamage(5);
    }
}
