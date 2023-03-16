using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomWinSkill : Skill
{
    private readonly int _skillID = 3;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "Воля Диментора";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "При использовании присуждает победу случайной стороне";
    public override string SkillDescription { get => _skillDescription; }

    private int _skillLevel = 1;
    public override int SkillLevel { get => _skillLevel; set => _skillLevel = value; }

    private readonly bool _onEnemy = true;
    public override bool OnEnemy { get => _onEnemy; }

    private int _cooldown = 3;
    public override int Cooldown { get => _cooldown; set => _cooldown = value; }

    [SerializeField] private BleedEffect _bleed;
    private Unit _target;
    public override Unit Target { get => _target; set => _target = value; }

    public override void CauseEffect()
    {
        _target.TakeDamage(5);
        _bleed.CurrentDurationSet();
        _bleed.Effect(_target);
    }
    public override void AddEffect()
    {
        _target.SetCurrentEffects(_bleed);
    }
}
