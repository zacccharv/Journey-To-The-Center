using TMPro;
using UnityEngine;

public class DataText : MonoBehaviour
{
    public static System.Action OnResourceUpdate;
    public static System.Action OnShopUpdate;
    public TextMeshProUGUI resourceText, shopText;
    public DrillInteraction drillInteraction;

    void OnEnable()
    {
        OnResourceUpdate += UpdateResourceText;
        OnShopUpdate += UpdateShopText;
    }

    void OnDisable()
    {
        OnResourceUpdate -= UpdateResourceText;
        OnShopUpdate -= UpdateShopText;
    }

    public void UpdateResourceText()
    {
        resourceText.text = "## RESOURCES\n" +
                            "Stone = " + ResourceManager.instance.stone + "\n" +
                            "Coal = " + ResourceManager.instance.coal + "\n" +
                            "Iron = " + ResourceManager.instance.ironOre + "\n" +
                            "Copper = " + ResourceManager.instance.copperOre + "\n" +
                            "\n" +
                            "## DRILL DATA\n" +
                            "Depth = " + DrillData.instance.drillDepth + "\n" +
                            "Level = " + DrillData.instance.drillLevel + "\n" +
                            "Power = " + DrillData.instance.drillPower + "\n" +
                            "Speed = " + DrillData.instance.drillSpeed;
    }

    public void UpdateShopText()
    {
        if (ShopManager.instance.DrillUpgrades.Count == 0)
        {
            shopText.text = "## SHOP ITEMS\n" +
                            "No items available";
            return;
        }

        shopText.text = "## SHOP ITEMS\n" +
                        "Current Item: " + ShopManager.instance.DrillUpgrades[0].itemName + "\n" +
                        "Stone Cost = " + ShopManager.instance.DrillUpgrades[0].stoneCost + "\n" +
                        "Coal Cost = " + ShopManager.instance.DrillUpgrades[0].coalCost + "\n" +
                        "Iron Cost = " + ShopManager.instance.DrillUpgrades[0].ironCost + "\n" +
                        "Copper Cost = " + ShopManager.instance.DrillUpgrades[0].copperCost + "\n";
    }

    public static void UpdateResources()
    {
        OnResourceUpdate?.Invoke();
    }

    internal static void UpdateShop()
    {
        OnShopUpdate?.Invoke();
    }
}
