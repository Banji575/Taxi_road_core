using UnityEngine;

public abstract class BaseRule : ScriptableObject, IRule
{
    public abstract void Execute(Car car);
    
}
