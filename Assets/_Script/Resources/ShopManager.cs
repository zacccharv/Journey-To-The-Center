using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public List<ShopItem> DrillUpgrades = new();
    public List<ShopItem> Machines = new();

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
        if (upgradeItem.itemType == ItemType.Machine)
            return Machines.Contains(upgradeItem);
        else if (upgradeItem.itemType == ItemType.DrillUpgrade)
            return DrillUpgrades.Contains(upgradeItem);
        else
            return false;
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
            Debug.Log("Purchased: " + item.itemName);

            if (item.itemType == ItemType.DrillUpgrade)
            {
                RemoveShopItem(item);
                DrillData.instance.UpgradeDrill();
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
        if (item.itemType == ItemType.DrillUpgrade)
        {
            DrillUpgrades.Remove(item);
        }
        else if (item.itemType == ItemType.Machine)
        {
            Machines.Remove(item);
        }

        DataText.instance.RemoveShopItem(item);
    }
}