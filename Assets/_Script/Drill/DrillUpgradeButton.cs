using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DrillUpgradeButton : MonoBehaviour
{
    [SerializeField] private ShopItemContainer shopItemContainer;
    private ShopItem upgradeItem;
    private Button _upgradeButton;

    private void Awake()
    {
        _upgradeButton = GetComponent<Button>();
    }

    void Update()
    {
        if (ShopManager.instance.DrillUpgrades.Count == 0)
        {
            _upgradeButton.interactable = false;
            return;
        }

        upgradeItem = shopItemContainer.shopItem;

        if (ShopManager.instance.CanAfford(upgradeItem))
        {
            // Enable the upgrade button
            _upgradeButton.interactable = true;
        }
        else
        {
            // Disable the upgrade button
            _upgradeButton.interactable = false;
        }
    }

    public void OnUpgradeButtonClicked()
    {
        if (ShopManager.instance.HasItem(upgradeItem))
        {
            ShopManager.instance.TryPurchase(upgradeItem);
        }
    }
}
