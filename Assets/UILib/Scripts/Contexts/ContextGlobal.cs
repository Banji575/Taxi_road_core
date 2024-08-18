using UnityEngine;

[CreateAssetMenu(fileName = "ContextGlobal", menuName = "Context/Global Context", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Информация об устройстве")]
    public string OSVersion;                  // Версия ОС устройства
    public string DeviceModel;                // Модель устройства
    public string Platform;                   // Платформа (например, Windows, iOS)
    public string DevicePerformanceClass;     // Класс производительности устройства (например, ultra)
    public int DeviceRamSizeKB;               // Размер оперативной памяти устройства в килобайтах

    [Space(10)]
    [Header("Состояние игры и игрока")]
    public int GameVersion;                   // Версия игры
    public bool IsInternetAvailable;          // Доступен ли интернет
    public string StoreType;                  // Тип магазина (например, yandex)
    public bool IsCheater;                    // Флаг, обозначающий читера
    public long CurrentTime;                  // Текущее время в Unix формате (миллисекунды с 1970 года)
    public string Region;                     // Регион пользователя (например, RU)
    public string RegionByIP;                 // Регион пользователя, определённый по IP (например, rs)
    public string Locale;                     // Локаль пользователя (например, ru)
    public string currencyCode;               // Код и классификатор валюты
    public bool DevMode;                      // Флаг режима разработчика
    public bool NeedUpdate;                   // Необходимо обновить игру

    [Space(10)]
    [Header("Настройки звука и вибрации")]
    public bool SoundOn;                      // Звук включен
    public bool MusicOn;                      // Музыка включена
    public bool VibroOn;                      // Вибрация включена

    [Space(10)]
    [Header("Баланс игрока")]
    public ScriptableObject playerStoreBalance;  // Ссылка на другой ScriptableObject
    public ScriptableObject playerLevelBalance;  // Ссылка на другой ScriptableObject


    public int maxLevel; // максимальный уровень на котором можно играть
    public int setLevel; // текущий уровень

    public LevelBalance levelBalance;
}
