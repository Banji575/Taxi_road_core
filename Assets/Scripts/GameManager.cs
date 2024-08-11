using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int changedLevel;

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

    public void NextLevel()
    {
        if (currentLevel)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[currentLevelCount], null);
        OnStartNextLevel?.Invoke(this, new OnStartNextLevelEventArgs { level = currentLevel });
        currentLevelCount++;
    }

    public void NextLevel(int levelCount)
    {
        if (currentLevel)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[levelCount], null);
        OnStartNextLevel?.Invoke(this, new OnStartNextLevelEventArgs { level = currentLevel });
        currentLevelCount = levelCount + 1;
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Сохраняем объект при смене сцены
        }
        else
        {
            Destroy(gameObject);  // Уничтожаем дубликат объекта
        }
    }
    private void Start()
    {
        LevelController.Instance.OnLevelEnd += LevelController_OnLevelEnd;
    }

    private void LevelController_OnLevelEnd(object sender, EventArgs e)
    {
        NextLevel();
    }
}
