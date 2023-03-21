using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BleedAtack : Skill
{
    private readonly int _skillID = 0;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "Ворез пены";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "Порезать вену и наложить кровотечение";
    public override string SkillDescription { get => _skillDescription; }

    private int _skillLevel = 1;
    public override int SkillLevel { get => _skillLevel; set => _skillLevel = value; }

    private readonly bool _onEnemy = true;
    public override bool OnEnemy { get => _onEnemy; }
    private int _damage = 5;

    private int _cooldown = 3;
    public override int Cooldown { get => _cooldown; set => _cooldown = value; }

    [SerializeField] private BleedEffect _bleed;
    private Unit _target;
    public override Unit Target { get => _target; set => _target = value; }
    [SerializeField] private Image _icon;
    public override Image Icon => _icon;
    public override int Damage => _damage;

    public override void CauseEffect(float modificator)
    {
        _target.TakeDamage(Convert.ToInt32(_damage * modificator + 0.5));
        _bleed.CurrentDurationSet();
        _bleed.Effect(_target);
    }
    public override void AddEffect()
    {
        _target.SetCurrentEffects(_bleed);
    }
}
