using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDataText : MonoBehaviour
{
    public ScrollRect shopScrollView;
    public GameObject shopItemContainerPrefab, shopCategoryPrefab;
    public TextMeshProUGUI shopPurchaseCount, redTitle;
    [HideInInspector] public Dictionary<ShopItem, GameObject> shopItemContainers = new();
    [HideInInspector] public Dictionary<ItemType, GameObject> shopCategoryContainers = new();
    public void UpdatePurchasableCount()
    {
        // count number of purchasable items in _shopItemContainers with Linq
        int ct = shopItemContainers.Count((x) => ShopManager.instance.CanAfford(x.Key));

        if (ct > 0)
        {
            shopPurchaseCount.text = ct.ToString();
            redTitle.text = "Can Buy: ";
        }
        else
        {
            shopPurchaseCount.text = "";
            redTitle.text = "";
        }
    }

    // TODO: add rows for categories, will better organize the shop 
    public void InitializeShopText()
    {
        // create category rows
        for (int i = 0; i < ShopManager.instance.AvailableItems.Count; i++)
        {
            ShopItem item = ShopManager.instance.AvailableItems[i];
            ItemType currentCategory = item.itemType;

            // create category row
            GameObject categoryBox;
            if (!shopCategoryContainers.ContainsKey(currentCategory))
            {
                categoryBox = Instantiate(shopCategoryPrefab, shopScrollView.content);
                categoryBox.GetComponentInChildren<TextMeshProUGUI>().text = $"<color=#FFE2B8><b>##{ConvertPascalToRegularCase(currentCategory.ToString())}</b></color>";
                shopCategoryContainers.Add(currentCategory, categoryBox);
            }
            else
            {
                categoryBox = shopCategoryContainers[currentCategory];
            }

            // put item container in category
            GameObject container = Instantiate(shopItemContainerPrefab, categoryBox.transform.GetChild(2).transform);
            container.GetComponent<ShopItemContainer>().Initialize(item);
            shopItemContainers.Add(item, container);
        }

        static string ConvertPascalToRegularCase(string pascalCaseString)
        {
            return Regex.Replace(pascalCaseString, "(?<=[a-z])([A-Z])", " $1");
        }
    }

    public void RemoveShopItem(ShopItem item)
    {
        if (shopItemContainers.TryGetValue(item, out GameObject container))
        {
            Destroy(container);
            shopItemContainers.Remove(item);
        }
    }

}
