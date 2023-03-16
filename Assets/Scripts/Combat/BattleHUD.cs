
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private BattleContainer _battleContainer;
    [SerializeField] private Slider[] _hpBars = new Slider[8];
    [SerializeField] private Text _description;
    public void SetupBattleHUD(Unit[] units)
    {
        HPBarValueChange(units);
        _description.text = "���� ���� �����������";
    }
    public void HPBarValueChange(Unit[] units)
    {
         for (int i = 0; i < units.Length; i++)
        {
            _hpBars[i].maxValue = units[i].MaxHP;
            _hpBars[i].value = units[i].CurrentHP;
        }

    }
    public void DisplayUnitDescription(Unit target)
    {
        _description.text = target.Name+ "\n �������: " + target.Lvl.ToString() + 
            "\n ��������: " + target.CurrentHP.ToString() +"/"+ target.MaxHP.ToString() + 
            "\n �����: "+ target.Armor.ToString() + "\n ��������: " + target.Sanity.ToString();
    }
    public void DisplaySkillDescriprion(Skill skill)
    {
        _description.text = skill.SkillName + "\n" + skill.SkillDescription + "\n �������: " + skill.SkillLevel.ToString();
    }

}
