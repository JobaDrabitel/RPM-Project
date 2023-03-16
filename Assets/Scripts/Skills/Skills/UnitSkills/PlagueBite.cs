using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlagueBite : Skill
{
    private readonly int _skillID = 2;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "���� �����";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "���� ���� ��������������";
    public override string SkillDescription { get => _skillDescription; }

    private int _skillLevel = 1;
    public override int SkillLevel { get => _skillLevel; set => _skillLevel = value; }

    private readonly bool _onEnemy = true;
    public override bool OnEnemy { get => _onEnemy; }

    private int _cooldown = 3;
    public override int Cooldown { get => _cooldown; set => _cooldown = value; }

    [SerializeField] private PlagueEffect _plague;
    private Unit _target;
    public override Unit Target { get => _target; set => _target = value; }
    private int _damage = 5;
    public override int Damage { get => _damage; }

    public override void AddEffect()
    {
        _plague.Effect(_target);

    }
    public override void CauseEffect(float modificator)
    {
        _target.TakeDamage(Convert.ToInt32(_damage * modificator + 0.5));
        _target.SetCurrentEffects(_plague);
    }
}
