using UnityEngine;

[CreateAssetMenu(menuName ="CarRules/CarRuleSet")]
public class CarRuleSet : ScriptableObject
{
    public BaseRule[] rules;
    public Sprite[] sprites;
}
