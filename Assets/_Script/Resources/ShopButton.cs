using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    private TextMeshProUGUI buttonText;
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnShopButtonClicked);
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnShopButtonClicked()
    {
        if (!shopPanel.activeInHierarchy)
        {
            shopPanel.SetActive(true);
            buttonText.text = "Close";
        }
        else
        {
            shopPanel.SetActive(false);
            buttonText.text = "Open";
        }
    }
}
