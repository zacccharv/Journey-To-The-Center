using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int stone = 0;
    public int ironOre = 0;
    public int copperOre = 0;
    public int coal = 0;

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

    public void AddCopperOre(int amount)
    {
        copperOre += amount;
        Debug.Log("Copper Ore: " + copperOre);
    }

    public void AddIronOre(int amount)
    {
        ironOre += amount;
        Debug.Log("Iron Ore: " + ironOre);
    }

    public void AddCoal(int amount)
    {
        coal += amount;
        Debug.Log("Coal: " + coal);
    }

    public void AddStone(int amount)
    {
        stone += amount;
        Debug.Log("Stone: " + stone);
    }

    /// <summary>
    /// Main mining function that determines the type and amount of resources to mine.
    /// </summary>
    public void MineForResources()
    {

        int resourceType = Random.Range(0, DrillData.instance.drillLevel + 1);
        int amount = Random.Range(1, DrillData.instance.drillLevel + 1);

        switch (resourceType)
        {
            case 0:
                break;
            case 1:
                AddStone(amount * DrillData.instance.drillLevel);
                break;
            case 2:
                AddCoal(amount * DrillData.instance.drillLevel / 2);
                break;
            case 3:
                AddIronOre(amount * DrillData.instance.drillLevel / 3);
                break;
            case 4:
                AddCopperOre(amount * DrillData.instance.drillLevel / 4);
                break;
        }

        DataText.UpdateResources();
    }

    /// <summary>
    /// Mines for resources based on the specified resource type and amount.
    /// 1. Stone
    /// 2. Coal
    /// 3. Iron Ore
    /// 4. Copper Ore
    /// </summary>
    /// <param name="resourceType">The type of resource to mine.</param>
    /// <param name="amount">The amount of resource to mine.</param>
    public void MineForResources(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Stone:
                AddStone(amount);
                break;
            case ResourceType.Coal:
                AddCoal(amount);
                break;
            case ResourceType.Iron:
                AddIronOre(amount);
                break;
            case ResourceType.Copper:
                AddCopperOre(amount);
                break;
        }

        DataText.UpdateResources();
    }
}
