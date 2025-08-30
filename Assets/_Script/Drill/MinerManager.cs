using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public GameObject stoneMine, coalMine, ironMine, copperMine, drillAssistant;

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