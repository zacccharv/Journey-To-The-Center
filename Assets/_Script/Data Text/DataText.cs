using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DataText : MonoBehaviour
{
    public static DataText instance;
    public static System.Action OnResourceUpdate;
    public static System.Action OnShopUpdate;
    public static System.Action OnShopInit;
    public TextMeshProUGUI resourceText, shopText;
    public ScrollRect shopScrollView;
    public GameObject shopItemContainerPrefab;
    public DrillInteraction drillInteraction;
    [HideInInspector] public Dictionary<ShopItem, GameObject> _shopItemContainers = new();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void InitializeShopText()
    {
        foreach (var item in ShopManager.instance.DrillUpgrades)
        {
            GameObject container = Instantiate(shopItemContainerPrefab, shopScrollView.content);
            container.GetComponent<ShopItemContainer>().Initialize(item);
            _shopItemContainers.Add(item, container);
        }

        foreach (var item in ShopManager.instance.Machines)
        {
            GameObject container = Instantiate(shopItemContainerPrefab, shopScrollView.content);
            container.GetComponent<ShopItemContainer>().Initialize(item);
            _shopItemContainers.Add(item, container);
        }
    }

    public void RemoveShopItem(ShopItem item)
    {
        if (_shopItemContainers.TryGetValue(item, out GameObject container))
        {
            Destroy(container);
            _shopItemContainers.Remove(item);
        }
    }
}
