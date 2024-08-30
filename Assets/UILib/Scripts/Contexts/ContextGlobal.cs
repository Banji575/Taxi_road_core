using UnityEngine;

[CreateAssetMenu(fileName = "ContextGlobal", menuName = "Context/Global Context", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Информация об устройстве")]
    public string OSVersion;                  // Версия ОС устройства
    public string DeviceModel;                // Модель устройства
    public string Platform;                   // Платформа
    public string DevicePerformanceClass;     // Класс производительности устройства (например, ultra)
    public int DeviceRamSizeKB;               // Размер оперативной памяти устройства в килобайтах
    public bool isTouchInput;                 // Поддержка сенсорного ввода

    [Space(10)]
    [Header("Состояние игры и игрока")]
    public int GameVersion;                   // Версия игры
    public bool IsInternetAvailable;          // Доступен ли интернет
    public string StoreType;                  // Тип магазина
    public bool IsCheater;                    // Флаг, обозначающий читера
    public long CurrentTime;                  // Текущее время в Unix формате 
    public string Region;                     // Регион пользователя
    public string RegionByIP;                 // Регион пользователя, определённый по IP
    public string Locale;                     // Локаль пользователя
    public string CurrencyCode;               // Код валюты пользователя
    public bool DevMode;                      // Флаг режима разработчика
    public bool NeedUpdate;                   // Необходимо обновить игру

    [Space(10)]
    [Header("Настройки звука и вибрации")]
    public bool SoundOn;                      // Включён ли звук
    public bool MusicOn;                      // Включена ли музыка
    public bool VibroOn;                      // Включена ли вибрация

    [Space(10)]
    [Header("Баланс уровней")]
    public ScriptableObject playerLevelBalance;  // Баланс уровней игрока
    public int maxLevel;                      // Максимальный уровень, который можно достиг
    public int setLevel;                      // Текущий уровень

<<<<<<< HEAD
    public LevelBalance playerLevelBalance;  // Ссылка на другой ScriptableObject

    public ScriptableObject playerStoreBalance;
    [SaveableField]
    public int maxLevel; // максимальный уровень на котором можно играть
    
    public int setLevel; // текущий уровень
=======
    [Space(10)]
    [Header("Баланс магазина")]
    public LevelBalance playerStoreBalance;   // Баланс магазина игрока
>>>>>>> dev/ui_libs

}
