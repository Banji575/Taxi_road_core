using UnityEngine;

[CreateAssetMenu(fileName = "StoreOffer", menuName = "Store/Store Offer")]
public class Offer : ScriptableObject
{
    [Header("Основная информация")]
    public string offerId;          // ID предложения
    public string offerName;        // Название предложения
    
    [Space(10)]
    [Header("Детали предложения")]
    public GameObject offerPrefab;   // Ссылка на префаб
    public GameObject windowPrefab;  // Ссылка на префаб окна
    public float price;              // Стоимость

    [Space(10)]
    [Header("Награда")]
    public float rewardCoins;        // Награда (монеты)
}
