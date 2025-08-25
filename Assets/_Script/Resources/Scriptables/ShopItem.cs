using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    [TextArea] public string description;
    public ItemType itemType;
    public MachineType machineType;
    public int stoneCost;
    public int coalCost;
    public int ironCost;
    public int copperCost;
}