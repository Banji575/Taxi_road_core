using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreBalance ", menuName = "Store/Store Balance")]
public class StoreBalance : ScriptableObject
{
    public List<StoreOffer> offers;
}
