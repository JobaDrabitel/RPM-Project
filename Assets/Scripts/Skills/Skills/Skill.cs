using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    public abstract int SkillId { get;}
    public abstract string SkillName { get;}
    public abstract string SkillDescription { get;}
    public abstract int SkillLevel { get; set; }
    public abstract bool OnEnemy { get; }
    public abstract int Cooldown { get; set; }
    public abstract int Damage { get;}   
    public abstract Image Icon { get; }
    public abstract Unit Target { get; set; }
    public abstract void AddEffect();
    public abstract void CauseEffect(float modificator);
}
