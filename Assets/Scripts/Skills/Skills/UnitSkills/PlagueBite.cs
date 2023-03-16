using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueBite : Skill
{
    private readonly int _skillID = 2;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "Укус СПИДа";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "Надо было предохраняться";
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

    public override void AddEffect()
    {
        _target.TakeDamage(5);
        _target.SetCurrentEffects(_plague);
    }
    public override void CauseEffect()
    {
        _plague.Effect(_target);
    }
}
