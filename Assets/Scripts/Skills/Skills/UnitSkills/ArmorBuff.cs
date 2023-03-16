using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBuff : Skill
{
    private readonly int _skillID = 0;
    public override int SkillId { get => _skillID; }
    private readonly string _skillName = "Железное гузно";
    public override string SkillName { get => _skillName; }

    private readonly string _skillDescription = "Жирный как поезд пассажирный";
    public override string SkillDescription { get => _skillDescription; }

    private int _skillLevel = 1;
    public override int SkillLevel { get => _skillLevel; set => _skillLevel = value; }

    private readonly bool _onEnemy = false;
    public override bool OnEnemy { get => _onEnemy; }

    private int _cooldown = 3;
    public override int Cooldown { get => _cooldown; set => _cooldown = value; }

    [SerializeField] private ArmorBuffEffect _armorBuff;
    private Unit _target;
    public override Unit Target { get => _target; set => _target = value; }

    public override void AddEffect()
    {
        _target.SetCurrentEffects(_armorBuff);
    }
    public override void CauseEffect()
    {
        _armorBuff.Effect(_target);
    }
}
