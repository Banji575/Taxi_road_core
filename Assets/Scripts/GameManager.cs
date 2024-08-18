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

    [Header("New level system")]
    
    public GameData globalContext;
   

    private void SetGameData()
    {
        globalContext.setLevel = 0;

    }

    public void NextLevel()
    {
        globalContext.setLevel++;
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

    }


}
