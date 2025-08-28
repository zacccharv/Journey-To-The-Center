using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public struct ShopItemInfo
    {
        public string itemName;
        [TextArea]
        public string description;
        public int stoneCost;
        public int coalCost;
        public int ironCost;
        public int copperCost;
    }

    public static ShopManager instance;
    public List<ShopItem> DrillUpgrades = new();
    public List<ShopItem> Machines = new();
    [SerializeField] private List<ShopItemInfo> Items = new();
    public List<ShopItem> AvailableItems { get; set; } = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AvailableItems.AddRange(DrillUpgrades);
        AvailableItems.AddRange(Machines);

        for (int i = 0; i < AvailableItems.Count; i++)
        {
            Items.Add(new ShopItemInfo
            {
                itemName = AvailableItems[i].itemName,
                description = AvailableItems[i].description,
                stoneCost = AvailableItems[i].stoneCost,
                coalCost = AvailableItems[i].coalCost,
                ironCost = AvailableItems[i].ironCost,
                copperCost = AvailableItems[i].copperCost
            });
        }

        DataText.instance.InitializeShopText();
    }

    public bool CanAfford(ShopItem item)
    {
        if (!HasItem(item))
            return false;

        // Check if the player has enough currency to afford the item
        if (ResourceManager.instance.stone >= item.stoneCost &&
            ResourceManager.instance.coal >= item.coalCost &&
            ResourceManager.instance.ironOre >= item.ironCost &&
            ResourceManager.instance.copperOre >= item.copperCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasItem(ShopItem upgradeItem)
    {
        return AvailableItems.Contains(upgradeItem);
    }

    public void TryPurchase(ShopItem item)
    {
        if (CanAfford(item))
        {
            // Deduct the cost from the player's currency
            ResourceManager.instance.stone -= item.stoneCost;
            ResourceManager.instance.coal -= item.coalCost;
            ResourceManager.instance.ironOre -= item.ironCost;
            ResourceManager.instance.copperOre -= item.copperCost;

            // Add the item to the player's inventory or apply its effects
            Debug.Log("Purchased: " + item.itemName + " at " + Time.time + " it cost " + item.stoneCost + " stone, " + item.coalCost + " coal, " + item.ironCost + " iron, " + item.copperCost + " copper.");

            if (item.itemType == ItemType.DrillUpgrade)
            {
                RemoveShopItem(item);
                DrillData.instance.UpgradeDrill();
                ResourceManager.instance._extraAddition++;
            }
            else if (item.itemType == ItemType.Machine)
            {
                RemoveShopItem(item);
                DrillData.instance.PurchaseMachine(item.machineType);
            }

            DataText.instance.UpdateResourceText();
        }
        else
        {
            Debug.Log("Cannot afford: " + item.itemName);
        }
    }

    public void RemoveShopItem(ShopItem item)
    {
        AvailableItems.Remove(item);
        DataText.instance.RemoveShopItem(item);
    }
}