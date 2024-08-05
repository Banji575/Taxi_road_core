using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event EventHandler OnCarEscape;
    public event EventHandler<OnStartNextLevelEventArgs> OnStartNextLevel;

    public class OnStartNextLevelEventArgs : EventArgs
    {
       public Level level;
    }

    private int maxCarToNextLevel;

    [SerializeField]
    private List<Level> levels;

    private int currentLevelCount = 0;
    private Level currentLevel;

    private void NextLevel()
    {
        if (currentLevel)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[currentLevelCount], null);
        OnStartNextLevel?.Invoke(this, new OnStartNextLevelEventArgs { level = currentLevel });
        currentLevelCount++;
    }



    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LevelController.Instance.OnLevelEnd += LevelController_OnLevelEnd;
        NextLevel();
    }

    private void LevelController_OnLevelEnd(object sender, EventArgs e)
    {
        NextLevel();
    }
}
