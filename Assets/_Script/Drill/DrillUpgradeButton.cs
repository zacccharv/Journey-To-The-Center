using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DrillUpgradeButton : MonoBehaviour
{
    private ShopItem drillUpgradeItem;
    private Button _upgradeButton;

    private void Awake()
    {
        _upgradeButton = GetComponent<Button>();
    }

    void Update()
    {
        if (ShopManager.instance.shopItems.Count == 0)
        {
            _upgradeButton.interactable = false;
            return;
        }

        drillUpgradeItem = ShopManager.instance.shopItems[0];

        if (ShopManager.instance.CanAfford(drillUpgradeItem))
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
        if (ShopManager.instance.HasItem(drillUpgradeItem))
        {
            ShopManager.instance.TryPurchase(drillUpgradeItem);
        }
    }
}
