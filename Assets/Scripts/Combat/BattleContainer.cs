using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContainer : MonoBehaviour
{
    public Transform[] spawnpoints = new Transform[8];
    public GameObject[] prefabs = new GameObject[8];
    public Unit[] units = new Unit[8];
    public Unit currentUnit;
    public int turn;
}
