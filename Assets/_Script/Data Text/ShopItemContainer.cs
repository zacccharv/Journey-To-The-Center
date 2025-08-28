using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemContainer : MonoBehaviour
{
    public TextMeshProUGUI itemCostText, itemDescriptionText;
    public Image itemImage;
    public ShopItem shopItem;
    private Color stoneColor, coalColor, ironColor, copperColor;

    public void Initialize(ShopItem item)
    {
        stoneColor = DataText.instance.resourceDataText.stoneColor;
        coalColor = DataText.instance.resourceDataText.coalColor;
        ironColor = DataText.instance.resourceDataText.ironColor;
        copperColor = DataText.instance.resourceDataText.copperColor;
        shopItem = item;

        itemImage.color = shopItem.itemColor;
        itemCostText.text = $"<color=#FFE2B8>Item:</color> {shopItem.itemName}\n" +
                            $"<color=#{stoneColor.ToHexString()}><b>Stone Cost:</b></color> {shopItem.stoneCost}\n" +
                            $"<color=#{coalColor.ToHexString()}><b>Coal Cost:</b></color> {shopItem.coalCost}\n" +
                            $"<color=#{ironColor.ToHexString()}><b>Iron Cost:</b></color> {shopItem.ironCost}\n" +
                            $"<color=#{copperColor.ToHexString()}><b>Copper Cost:</b></color> {shopItem.copperCost}";

        itemDescriptionText.text = "<color=#FFE2B8><b>Description:</b></color> \n"
                                   + "\"" + shopItem.description + "\"";
    }
}
