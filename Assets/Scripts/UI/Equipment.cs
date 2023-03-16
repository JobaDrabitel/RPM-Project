using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public enum EquipSlot { HELMET, CUIRASS, SHOULDERS, JUJU, RING1, RING2, LEGS, BOOTS, LEFTARM, RIGHTARM }
    
    private Item[] _equipedItems = new Item[10];
}
