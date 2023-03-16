using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IEffect 
{
    public void Effect(Unit target);
    public abstract int Duration {get;}
    public abstract int CurrentDuration {get;}
    public abstract void CurrentDurationDecrease();
    public abstract void CurrentDurationSet();

}
