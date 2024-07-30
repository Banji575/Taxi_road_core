using UnityEngine;

[CreateAssetMenu(menuName ="Rules/TurnLeftRule")]
public class TurnLeftRule : BaseRule
{
    public override void Execute(Car car)
    {
        car.TurnLeft();
    }
}
