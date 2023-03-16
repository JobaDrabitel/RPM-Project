using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item", fileName = "ItemData")]
public class Item : ScriptableObject
{
    [SerializeField] private int iD;
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Equipment.EquipSlot _equipSlot;
    private enum QUALITY {POOR, COOMON, GOOD, WELL, MASTERLY, ARTEFACT }
    [SerializeField] private QUALITY quality;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private Skill skill;
}
