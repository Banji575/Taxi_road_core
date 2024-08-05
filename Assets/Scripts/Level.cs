using UnityEngine;

public class Level : MonoBehaviour
{
    public int CarCount { get; private set; }

    private void Awake()
    {
        CarCount = GetComponentsInChildren<Car>().Length;
    }

    private void Start()
    {
        
    }
}
