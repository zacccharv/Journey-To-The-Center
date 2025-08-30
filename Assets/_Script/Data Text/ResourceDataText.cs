using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceDataText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stoneText, coalText, ironText, copperText, drillDataText;
    public Color stoneColor, coalColor, ironColor, copperColor;

    public void UpdateText()
    {
        stoneText.text = $": {ResourceManager.instance.stone}\n";
        coalText.text = $": {ResourceManager.instance.coal}\n";
        ironText.text = $": {ResourceManager.instance.ironOre}\n";
        copperText.text = $": {ResourceManager.instance.copperOre}\n";

        drillDataText.text = $"<color=#FFE2B8><b>## DRILL DATA</b></color>\n" +
                            $"<color=#FFE2B8>Depth:</color> {DrillData.instance.drill.drillDepth}m / {Drill.centerOfTheEarthMeters:n0}m\n" +
                            $"<color=#FFE2B8>Level:</color> {DrillData.instance.drill.drillLevel}\n" +
                            $"<color=#FFE2B8>Power:</color> {DrillData.instance.drill.drillPower}\n";
    }

}
