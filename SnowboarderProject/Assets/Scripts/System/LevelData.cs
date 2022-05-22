using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Data", fileName = "New Level Data", order = 52)]
public class LevelData : ScriptableObject
{
    public bool[] levelPassed;
}
