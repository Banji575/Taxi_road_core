using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private int CarsInLevel;
    private Level currentLevel = null;

    public event EventHandler OnLevelEnd;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        GameManager.Instance.OnStartNextLevel += GameManager_OnStartNextLevel;
    }

    private void GameManager_OnStartNextLevel(object sender, GameManager.OnStartNextLevelEventArgs e)
    {
        if (currentLevel)
        {
            Destroy(currentLevel.gameObject);
            Debug.Log("destroy level");
            currentLevel = null;
        }
        currentLevel = e.level;
        CarsInLevel = currentLevel.CarCount;
        Debug.Log("level controller on start new level" + CarsInLevel.ToString());
    }

    public void EscapeCar()
    {
        CarsInLevel--;

        if(CarsInLevel <= 0)
        {
            OnLevelEnd?.Invoke(this, EventArgs.Empty);
        }

    }

}
