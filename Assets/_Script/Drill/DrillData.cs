using UnityEngine;

public class DrillData : MonoBehaviour
{
    public static DrillData instance;
    public float drillDepth = 0.0f;
    public int drillLevel = 1;
    public float drillSpeed = 1.0f; // Time in seconds between each mining action
    public float drillPower = 0.25f; // Amount of resource mined per action

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DrillDown(float amount)
    {
        drillDepth += amount * drillPower;
        drillDepth = Mathf.Round(drillDepth * 100f) / 100f; // Round to 2 decimal places
        ResourceManager.instance.MineForResources();
    }

    public void UpgradeDrill()
    {
        drillLevel++;
        drillPower *= 1.2f; // Increase amount of resource mined per action by 20%
    }
}
