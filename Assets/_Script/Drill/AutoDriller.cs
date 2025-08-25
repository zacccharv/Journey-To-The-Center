using UnityEngine;

public class AutoDriller : MonoBehaviour
{
    public ResourceType resourceType = ResourceType.Nothing;
    public int amountPerDrill = 1; // Amount of resource to mine each drill action
    public float drillInterval = 1.0f; // Time in seconds between each automatic drill action
    private float drillTimer = 0.0f;

    void Update()
    {
        drillTimer += Time.deltaTime;

        if (drillTimer >= drillInterval)
        {
            drillTimer = 0.0f;
            ResourceManager.instance.MineForResources(resourceType, amountPerDrill);
        }
    }

    public void SetDrillParameters(int amount, float interval)
    {
        amountPerDrill = amount;
        drillInterval = interval;
    }
}
