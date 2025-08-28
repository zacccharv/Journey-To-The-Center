using UnityEngine;

[RequireComponent(typeof(ResourceDataText))]
[RequireComponent(typeof(ShopDataText))]
[RequireComponent(typeof(EarthDataText))]
public class DataText : MonoBehaviour
{
    public static DataText instance;
    [HideInInspector] public ResourceDataText resourceDataText;
    [HideInInspector] public ShopDataText shopDataText;
    [HideInInspector] public EarthDataText earthDataText;

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

    void Start()
    {
        resourceDataText = GetComponent<ResourceDataText>();
        shopDataText = GetComponent<ShopDataText>();
        earthDataText = GetComponent<EarthDataText>();

        UpdateDataText();
    }

    public void UpdateDataText()
    {
        resourceDataText.UpdateText();

        shopDataText.UpdatePurchasableCount();

        earthDataText.UpdateText();
    }
}
