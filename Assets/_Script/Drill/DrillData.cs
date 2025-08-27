using UnityEngine;

public class DrillData : MonoBehaviour
{
    public static DrillData instance;
    public GameObject stoneMine, coalMine, ironMine, copperMine, drillAssistant;
    public float drillDepth = 0.0f;
    public int drillLevel = 1;
    public float drillSpeed = 1.0f; // Time in seconds between each mining action
    public float drillPower = 0.25f; // Amount of resource mined per action
    public const float centerOfTheEarthMeters = 6371000f;

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

    public void PurchaseMachine(MachineType machineType)
    {
        switch (machineType)
        {
            case MachineType.StoneMiner:
                stoneMine.SetActive(true);
                // Purchase logic for Stone Miner
                break;
            case MachineType.CoalMiner:
                coalMine.SetActive(true);
                // Purchase logic for Coal Miner
                break;
            case MachineType.IronMiner:
                ironMine.SetActive(true);
                // Purchase logic for Iron Miner
                break;
            case MachineType.CopperMiner:
                copperMine.SetActive(true);
                // Purchase logic for Copper Miner
                break;
            case MachineType.DrillAssistant:
                drillAssistant.SetActive(true);
                // Purchase logic for Drill Assistance
                break;
        }
    }
}