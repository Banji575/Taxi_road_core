using UnityEngine;
[CreateAssetMenu(menuName = "Rules/TurnRightRule")]
public class TurnRightRule : BaseRule
{
    public override void Execute(Car car)
    {
        car.TurnRight();
    }
}
