using TMPro;
using UnityEngine;

public class DataText : MonoBehaviour
{
    public static System.Action OnResourceUpdate;
    public TextMeshProUGUI resourceText, shopText;
    public DrillInteraction drillInteraction;

    void OnEnable()
    {
        OnResourceUpdate += UpdateResourceText;
    }

    void OnDisable()
    {
        OnResourceUpdate -= UpdateResourceText;
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
                            "Depth = " + drillInteraction.drillData.drillDepth + "\n" +
                            "Level = " + drillInteraction.drillData.drillLevel + "\n" +
                            "Power = " + drillInteraction.drillData.drillPower + "\n" +
                            "Speed = " + drillInteraction.drillData.drillSpeed;
    }

    public static void UpdateText()
    {
        OnResourceUpdate?.Invoke();
    }
}
