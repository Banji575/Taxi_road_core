using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelBalanceList", menuName = "Level/Level Balance List")]
public class LevelBalanceList : ScriptableObject
{
    public List<LevelBalance> offers;
}
