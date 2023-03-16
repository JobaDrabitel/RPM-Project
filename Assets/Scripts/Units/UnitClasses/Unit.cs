using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract string Name { get; set;}
    public abstract Sprite Icon { get; }
    public abstract int Lvl { get;}
    public abstract bool IsPlayable { get; set; }
    public abstract int MaxHP { get;  }
    public abstract int CurrentHP { get;}
    public abstract int Sanity { get; set; }
    public abstract int Damage { get; set; }
    public abstract int DodgeChance { get; set; }
    public abstract int Armor { get; set; }
    public abstract int CriticalChance { get; set; }
    public abstract int EXP { get; }
    public abstract int EXPForNewLvl { get; }
    public abstract int EXPForKill { get; }
    public abstract int Initiative { get; }
    public abstract void GetCurrentEffects();
    public abstract void SetCurrentEffects(IEffect effect);
    public abstract Skill GetSkill(int index);
    public abstract void SetSkill(int index, Skill skill);
    public enum StateMachine { WAIT, TURN, DEAD };
    public enum CreatureType { HUMAN, ANIMAL, MONSTER };
    public abstract StateMachine State { get; set; }
    public abstract void TakeDamage(int damage);
    public virtual void Die()
    {
        Debug.Log("Пук пук");
        this.gameObject.SetActive(false);
        this.State = StateMachine.DEAD;
    }
    public virtual void Atack(int damage, Unit target)
    {
        Debug.Log("НЫА");
        target.TakeDamage(damage);
    }
    protected abstract void LvlUp();
    public abstract void AddExp(int exp);
    public abstract void Heal(int heal);
    public abstract int SetRandomInitiative();
    public abstract void ChangeInitiative(int value);
    public virtual void UseSkill(int index, Unit unit, Unit target)
    {
        Skill skill = unit.GetSkill(index);
        skill.Target = target;
        string log = $"{unit.Name} использует {skill.SkillName} на {target.Name}!";
        Debug.Log(log);
        skill.AddEffect();
        skill.CauseEffect();
        unit.State = StateMachine.WAIT;
    }
    public abstract void SetMaxHP(int value);
    public abstract int ChooseTarget(Unit[] units);
}
