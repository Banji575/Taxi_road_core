using System;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum GameDataFields
{
    None = 0,
    MaxLevel = 1 << 0,   // 1
    SetLevel = 1 << 1,   // 2
    // Добавляйте остальные поля по мере необходимости
    Field1 = 1 << 2,     // 4
    Field2 = 1 << 3,     // 8
    Field3 = 1 << 4      // 16
}



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

    [Header("Selectable Fields for Saving")]
    [SerializeField]
    private GameDataFields selectedFields;

    private void Start()
    {
        
        /*SaveGameProgress();*/
        LoadGameProgress();
    }

    public void LoadGameProgress()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexProgressStorage.Instance.Load();
#endif
    }

    public void SaveGameProgress()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        List<string> fieldsToSave = new List<string>();

        if (selectedFields.HasFlag(GameDataFields.MaxLevel))
        {
            fieldsToSave.Add(nameof(globalContext.maxLevel));
        }
        YandexProgressStorage.Instance.Save(globalContext, fieldsToSave.ToArray());
#endif
    }

    private void SetGameData()
    {
        globalContext.setLevel = 0;

        SaveGameProgress();
    }

   

    public void NextLevel()
    {
        if(globalContext.setLevel == globalContext.maxLevel)
        {
            globalContext.maxLevel++;
        }
        globalContext.setLevel++;
        SaveGameProgress();
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


}
