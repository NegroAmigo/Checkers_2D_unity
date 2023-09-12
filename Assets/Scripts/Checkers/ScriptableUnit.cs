using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Checkers", menuName = "Sciptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction faction;
    public BaseChecker CheckerPrefab;
}

public enum Faction
{
    White = 0,
    Black = 1
}