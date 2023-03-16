using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public abstract int SkillId { get;}
    public abstract string SkillName { get;}
    public abstract string SkillDescription { get;}
    public abstract int SkillLevel { get; set; }
    public abstract bool OnEnemy { get; }
    public abstract int Cooldown { get; set; }
    public abstract Unit Target { get; set; }
    public abstract void AddEffect();
    public abstract void CauseEffect();
}
