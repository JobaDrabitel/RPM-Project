using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomWinEffect : MonoBehaviour
{   
    [SerializeField] WinDefiner _winDefiner;
    private int _duration = 1;
    private int _currentDuration = 1;

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
        System.Random rnd = new();
        if (rnd.Next(0,2) < 1)
        { }
            
    }
}
