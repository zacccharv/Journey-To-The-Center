using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemContainer : MonoBehaviour
{
    public TextMeshProUGUI itemCostText, itemDescriptionText;
    public Image itemImage;
    public ShopItem shopItem;

    public void Initialize(ShopItem item)
    {
        shopItem = item;

        itemImage.color = shopItem.itemColor;
        itemCostText.text = $"Item: {shopItem.itemName}\n" +
                            $"Stone Cost: {shopItem.stoneCost}\n" +
                            $"Coal Cost: {shopItem.coalCost}\n" +
                            $"Iron Cost: {shopItem.ironCost}\n" +
                            $"Copper Cost: {shopItem.copperCost}";

        itemDescriptionText.text = "Description: \n"
                                   + "\"" + shopItem.description + "\"";
    }
}
