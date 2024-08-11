using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Set level")]
public class Level : ScriptableObject
{
    [Header("Общая информация")]
    public string levelId;              // ID уровня
    public string levelName;            // Название уровня
    
    [Space(10)]
    [Header("Награды и штрафы")]
    public float rewardLevel;           // Награда за уровень
    public float penaltyLevel = -1f;    // Штраф за уровень (по умолчанию -1)
    
    [Space(10)]
    [Header("Механики уровня")]
    public float numberOfMoves = -1f;   // Количество ходов (по умолчанию -1, что означает неограниченное количество ходов)
    public bool hardLevel;              // Сложный уровень
    
    [Space(10)]
    [Header("Визуальные элементы")]
    public GameObject levelPrefab;      // Ссылка на префаб
    public GameObject levelTutorial;    // Префаб для туториала перед уровнем (если отсутствует — не показывается)
}
