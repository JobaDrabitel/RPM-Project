using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaDodge : Skill
{
    private readonly int _skillID = 0;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "Áàòòåðôëÿé";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "Êóïè ìêá...";
    public override string SkillDescription { get => _skillDescription; }

    private int _skillLevel = 1;
    public override int SkillLevel { get => _skillLevel; set => _skillLevel = value; }

    private readonly bool _onEnemy = false;
    public override bool OnEnemy { get => _onEnemy; }

    private int _cooldown = 3;
    public override int Cooldown { get => _cooldown; set => _cooldown = value; }

    [SerializeField] private DodgeEffect _dodgebuff;
    private Unit _target;
    public override Unit Target { get => _target; set => _target = value; }
    public override int Damage => throw new System.NotImplementedException();
    [SerializeField] private Image _icon;
    public override Image Icon => _icon;

    public override void AddEffect()
    {
        _target.SetCurrentEffects(_dodgebuff);
    }
    public override void CauseEffect(float modificator)
    {
        _dodgebuff.Effect(_target);
    }
}
