using UnityEngine;

[System.Serializable]
public class DrillData
{
    public float drillDepth = 0.0f;
    public int drillLevel = 1;
    public float drillSpeed = 1.0f; // Time in seconds between each mining action
    public float drillPower = 0.01f; // Amount of resource mined per action

    public void DrillDown(float amount)
    {
        drillDepth += amount;
        drillDepth = Mathf.Round(drillDepth * 100f) / 100f; // Round to 2 decimal places
        ResourceManager.instance.MineForResources();
    }
}
