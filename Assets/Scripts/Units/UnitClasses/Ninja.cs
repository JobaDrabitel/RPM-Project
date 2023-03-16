using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Unit
{
    private int _lvl = 1;
    [SerializeField] private Sprite _icon;
    private void OnMouseDown()
    {
        Debug.Log("на меня нажали");
    }
    public override int Lvl { get => _lvl; }
    private int _EXP = 0;
    private int _EXPForNewLvl = 100;
    public override int EXP => _EXP;
    public override int EXPForNewLvl => _EXPForNewLvl;
    private int _EXPForKill = 20;
    public override int EXPForKill => EXPForKill;
    private string _name = "Ниндзя";
    private bool _isPlayable;
    public override bool IsPlayable { get => _isPlayable; set => _isPlayable = value; }
    public override string Name { get =>_name; set => _name = value; } 
    private int _maxHP = 20;
    public override int MaxHP { get => _maxHP; }
    private int _currentHP = 20;
    public override int CurrentHP { get => _currentHP;}
    private int _sanity = 100;
    public override int Sanity { get => _sanity; set => _sanity = value; }
    private int _damage = 10;
    public override int Damage { get => _damage; set => _damage = value ; }
    private int _armor = 0;
    private int _initiative = 10;
    public override int Initiative => _initiative;
    public override int Armor { get => _armor; set => _armor = value; }
    private int _criticalChance = 5;
    public override int CriticalChance { get => _criticalChance; set => _criticalChance = value; }
    private int _dodgeChance = 5;
    public override int DodgeChance { get => _dodgeChance; set => _dodgeChance = value; }

    public override Sprite Icon => _icon;

    [SerializeField] private Skill[] _skills = new Skill[3];
    public override Skill GetSkill(int index)
    {
        return _skills[index];
    }
    public override void SetSkill(int index, Skill skill)
    {
        _skills[index] = skill;
    }
    private List<IEffect> _currentEffects = new List<IEffect>();
    public override void GetCurrentEffects()
    {
        foreach (IEffect effect in _currentEffects)
        {
            effect.Effect(this);
            effect.CurrentDurationDecrease();
            if (effect.CurrentDuration <= 0)
                _currentEffects.Remove(effect);
        }
    }
    public override void SetCurrentEffects(IEffect effect)
    {
        _currentEffects.Add(effect);
    }
    private StateMachine _state = StateMachine.WAIT;
    public override StateMachine State { get => _state; set => _state = value; }

    public override void Atack(int damage, Unit target)
    {
        base.Atack(damage, target);
        Debug.Log("Я твоя тень, кагами");
    }
    public override void TakeDamage(int damage)
    {
        _currentHP -= damage-_armor;
        string log = $"Ниндзя получил {damage} урона и теперь у него {_currentHP} хп";
        Debug.Log(log);
        if (_currentHP <= 0)
            Die();
    }
    public override void Die()
    {
        Debug.Log("Похуй проебали");
        this.gameObject.SetActive(false);
        this.State = StateMachine.DEAD;
    }
    protected override void LvlUp()
    {
        _lvl++;
        _maxHP += Convert.ToInt32(_maxHP * 0.1 + 0.5);
        _currentHP = _maxHP;
        _EXPForNewLvl *= 2;
        _EXPForKill *= 2;
        _initiative++;
    }
    public override void AddExp(int exp)
    {
        _EXP += exp;
        if (_EXP >= _EXPForNewLvl)
            LvlUp();
    }
    public override void Heal(int heal)
    {
        _currentHP += heal;
        if (_currentHP > _maxHP)
            _currentHP = _maxHP;
    }
    public override int SetRandomInitiative()
    {
        var rand = new System.Random();
        _initiative += rand.Next(10);
        return _initiative;
    }
    public override void ChangeInitiative(int value)
    {
        _initiative*=value;
    }
    public override void SetMaxHP(int value)
    {
        _maxHP += value;
        if (_maxHP <= 0)
            _maxHP = 0;
        if (_currentHP > _maxHP)
            TakeDamage(-value);
    }
    public override int ChooseTarget(Unit[] units)
    {
        int target = 0;
        double minDanger = units[0].CurrentHP + units[0].Armor + units[0].DodgeChance;

        for (int i = 0; i < units.Length; i++)
        {
            if (minDanger < units[i].CurrentHP + units[i].Armor + units[i].DodgeChance && units[i].State != Unit.StateMachine.DEAD)
            {
                minDanger = units[i].CurrentHP + units[i].Armor + units[i].DodgeChance;
                target = i;
            }
        }
        return target;
    }
}
