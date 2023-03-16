using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsSelector : MonoBehaviour
{
    [SerializeField] private GameObject unitIconPrefab;
    [SerializeField] Transform iconsSpawnPoint;
    [SerializeField] private List<Unit> playerUnits = new();
    [SerializeField] private List<Image> unitsIcons = new();
    private Unit[] _selectedUnits = new Unit[4];
    private Text _description;

    private void Start()
    {
        SpawnIcons();
    }
    public void DisplayUnitDescription(Unit target)
    {
        _description.text = target.Name + "\n Уровень: " + target.Lvl.ToString() +
            "\n Здоровье: " + target.CurrentHP.ToString() + "/" + target.MaxHP.ToString() +
            "\n Броня: " + target.Armor.ToString() + "\n Рассудок: " + target.Sanity.ToString();
    }
    private void SpawnIcons()
    {
        Transform currentSPTransform = iconsSpawnPoint;
        var currentSPPosition = iconsSpawnPoint.position;
        for (int i = 0; i < playerUnits.Count; i++)
            {
                unitsIcons.Add(Instantiate(unitIconPrefab, currentSPTransform).GetComponent<Image>());
                currentSPPosition.y -= 90;
                currentSPTransform.position = currentSPPosition;
                unitsIcons[i].sprite = playerUnits[i].Icon;
            }
    }
}
