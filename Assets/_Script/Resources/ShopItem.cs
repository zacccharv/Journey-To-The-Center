using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public int stoneCost;
    public int coalCost;
    public int ironCost;
    public int copperCost;
}