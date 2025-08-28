using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceDataText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceText;
    public Color stoneColor, coalColor, ironColor, copperColor;
    public void UpdateText()
    {
        resourceText.text = "<color=#FFE2B8><b>## RESOURCES</b></color>\n" +
                            $"<color=#{stoneColor.ToHexString()}><b>Stone:</b></color> {ResourceManager.instance.stone}\n" +
                            $"<color=#{coalColor.ToHexString()}><b>Coal:</b></color> {ResourceManager.instance.coal}\n" +
                            $"<color=#{ironColor.ToHexString()}><b>Iron:</b></color> {ResourceManager.instance.ironOre}\n" +
                            $"<color=#{copperColor.ToHexString()}><b>Copper:</b></color> {ResourceManager.instance.copperOre}\n" +
                            $"\n" +
                            $"<color=#FFE2B8><b>## DRILL DATA</b></color>\n" +
                            $"<color=#FFE2B8>Depth:</color> {DrillData.instance.drillDepth}m / {DrillData.centerOfTheEarthMeters:n0}m\n" +
                            $"<color=#FFE2B8>Level:</color> {DrillData.instance.drillLevel}\n" +
                            $"<color=#FFE2B8>Power:</color> {DrillData.instance.drillPower}\n" +
                            $"<color=#FFE2B8>Speed:</color> {DrillData.instance.drillSpeed}";
    }
}
