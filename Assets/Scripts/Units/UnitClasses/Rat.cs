using System;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Unit
{
    private int _lvl = 1;
    [SerializeField] private Sprite _icon;

    public override int Lvl { get => _lvl; }
    private int _EXP = 0;
    private int _EXPForNewLvl = 0;
    public override int EXP => _EXP;
    public override int EXPForNewLvl => _EXPForNewLvl;
    private int _EXPForKill = 20;
    public override int EXPForKill => EXPForKill;
    private bool _isPlayable;
    public override bool IsPlayable { get => _isPlayable; set => _isPlayable = value; }
    private string _name = "Крысо";
    public override string Name { get => _name; set => _name = value; }
    private int _maxHP = 10;
    public override int MaxHP { get => _maxHP; }
    public int _currentHP = 10;
    public override int CurrentHP { get => _currentHP;}
    public int _sanity = 100;
    public override int Sanity { get => _sanity; set => _sanity = value; }
    private int _damage = 5;
    public override int Damage { get => _damage; set => _damage = value; }
    private int _armor = 0;
    public override int Armor { get => _armor; set => _armor = value; }
    private int _criticalChance = 5;
    public override int CriticalChance { get => _criticalChance; set => _criticalChance = value; }
    private int _initiative = 9;
    public override int Initiative => _initiative;
    private int _dodgeChance = 5;
    public override int DodgeChance { get => _dodgeChance; set => _dodgeChance = value; }


    private List<IEffect> _currentEffects = new();
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

    private StateMachine _state;
    public override StateMachine State { get => _state; set =>_state = value; }

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
    public override void TakeDamage(int damage)
    {
        _currentHP -= damage-_armor;
        string log = $"Крыса получила {damage} урона и теперь у нее {_currentHP} хп";
        Debug.Log(log);
        if (_currentHP <= 0)
            Die();

    }
    protected override void LvlUp()
    {
        _lvl++;
        _maxHP += Convert.ToInt32(_maxHP * 0.1 + 0.5);
        _currentHP = _maxHP;
        _EXPForNewLvl *= 2;
        _EXPForKill *= 2;
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
        _initiative *= value;
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
        double maxInjuries = units[0].CurrentHP / units[0].MaxHP;

        for (int i = 0; i < units.Length; i++)
        {
            if (maxInjuries < units[i].CurrentHP / units[i].MaxHP && units[i].State != Unit.StateMachine.DEAD)
            {
                maxInjuries = units[i].CurrentHP / units[i].MaxHP;
                target = i;
            }
        }
        return target;
    }
}
