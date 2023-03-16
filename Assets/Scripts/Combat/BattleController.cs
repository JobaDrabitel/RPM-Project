using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleHUD battleHUD;
    [SerializeField] private BattleContainer battleContainer;
    private Unit _skillTarget;
    private Unit _currentUnit;
    private bool _isSkillUsed = false;
    private int _currentUnitNumber = 0;
    private Unit[] _sortedUnits = new Unit[8];
    private Unit[] _playerUnits = new Unit[4];
    private Unit[] _enemyUnits = new Unit[4];
    public UnityEvent EnemyTurnEvent;
    private void Start()
    {
        EnemyTurnEvent = new UnityEvent();
        EnemyTurnEvent.AddListener(OnEnemyAction);
        SpawnUnit();
        PrepareUnitsForBattle();
        ChangeTurn();
        battleHUD.SetupBattleHUD(battleContainer.units);
    }
    private void PrepareUnitsForBattle()
    {
        UnitArraysPrepare arraysPrepare = new UnitArraysPrepare();
        _sortedUnits = arraysPrepare.ArrayByInitiativeSort(battleContainer.units);
        _playerUnits = arraysPrepare.SetUnitsBySide(battleContainer.units, true);
        _enemyUnits = arraysPrepare.SetUnitsBySide(battleContainer.units, false);
    }
    private void CurrentUnitAction(int index, Unit unit, Unit target)
    {
        battleHUD.HPBarValueChange(battleContainer.units);
        battleHUD.DisplayUnitDescription(target);
        _currentUnit.UseSkill(index, unit, target);
        _skillTarget = null;
        _isSkillUsed = false;
        ChangeTurn();
        if (!_currentUnit.IsPlayable)
            StartCoroutine(EnemyAction());
    }

    public void OnSkill3ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(2);
            battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(2));
        }
    }
    public void OnSkill2ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(1);
            battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(1));
        }
    }
    public void OnSkill1ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(0);
            battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(0));
        }
    }
    public void ChangeTurn()
    {
        _currentUnit = _sortedUnits[_currentUnitNumber];
        if (_sortedUnits[_currentUnitNumber].State != Unit.StateMachine.DEAD)
        {
            if (_sortedUnits[_currentUnitNumber].IsPlayable)
                Debug.Log("Ваш ход!");
            else
            {
                EnemyTurnEvent.Invoke();
                Debug.Log("Ход врага!");
            }
            _sortedUnits[_currentUnitNumber].State = Unit.StateMachine.TURN;
            string log = $"Ходит {_currentUnit.Name} под номером {_currentUnitNumber+1}";
            Debug.Log(log);
            _currentUnitNumber++;
        }
        else
        {
            string log = $"Юнит {_currentUnit.Name} под номером {_currentUnitNumber+1} не может ходить так как умерчик!";
            Debug.Log(log);
            _currentUnitNumber++;
            ChangeTurn();
        }
        if (_currentUnitNumber >= _sortedUnits.Length)
            _currentUnitNumber = 0;
    }
    public IEnumerator EnemyAction()
    {
        int target = _currentUnit.ChooseTarget(_playerUnits);
        yield return new WaitForSeconds(2f);
        CurrentUnitAction(0, _currentUnit, battleContainer.units[target]);
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator PlayerAction(int index)
    {
        yield return new WaitUntil(() => _skillTarget != null);
        CurrentUnitAction(index, _currentUnit, _skillTarget);
        yield return new WaitForSeconds(1f);

    }
    public void SpawnUnit()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i <= 3)
            {
                GameObject playerClone = Instantiate(battleContainer.prefabs[i], battleContainer.spawnpoints[i]);
                playerClone.GetComponent<Unit>().IsPlayable = true;
                battleContainer.units[i] = playerClone.GetComponent<Unit>();
            }
            else
            {
                GameObject enemyClone = Instantiate(battleContainer.prefabs[i], battleContainer.spawnpoints[i]);
                enemyClone.GetComponent<Unit>().IsPlayable = false;
                battleContainer.units[i] = enemyClone.GetComponent<Unit>();
            }
        }
    }
    public void GetTarget(int index)
    {
        if (_isSkillUsed && battleContainer.units[index].State!=Unit.StateMachine.DEAD)
            _skillTarget = battleContainer.units[index];
            battleHUD.DisplayUnitDescription(battleContainer.units[index]);
    }
    public void OnEnemyAction()
    {
        EnemyAction();
        battleHUD.SetupBattleHUD(battleContainer.units);
    }
}

