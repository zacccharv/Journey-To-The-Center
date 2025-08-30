using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    [Header("Resources")]
    public int stone = 0;
    public int coal = 0;
    public int ironOre = 0;
    public int copperOre = 0;
    public int diamond = 0;

    [Header("Resource Dividers")]
    [SerializeField] private float _stoneDivider = 1.0f;
    [SerializeField] private float _coalDivider = 1.0f;
    [SerializeField] private float _ironDivider = 1.0f;
    [SerializeField] private float _copperDivider = 1.0f;

    // [SerializeField] private float _diamondDiver = 1.0f;
    [HideInInspector] public float _extraAddition = 0.0f;

    void Awake()
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

    public void AddCopperOre(int amount)
    {
        copperOre += amount;
    }

    public void AddIronOre(int amount)
    {
        ironOre += amount;
    }

    public void AddCoal(int amount)
    {
        coal += amount;
    }

    public void AddStone(int amount)
    {
        stone += amount;
    }

    /// <summary>
    /// Main mining function that determines the type and amount of resources to mine.
    /// </summary>
    public void MineForResources()
    {
        int resourceType = Mathf.FloorToInt(Random.Range(0, DrillData.instance.drill.drillLevel + 1));

        switch (resourceType)
        {
            case 0:
                break;
            case 1:
                AddStone(ResourceDivider(DrillData.instance.drill.drillLevel, _stoneDivider));
                break;
            case 2:
                AddCoal(ResourceDivider(DrillData.instance.drill.drillLevel, _coalDivider));
                break;
            case 3:
                AddIronOre(ResourceDivider(DrillData.instance.drill.drillLevel, _ironDivider));
                break;
            case 4:
                AddCopperOre(ResourceDivider(DrillData.instance.drill.drillLevel, _copperDivider));
                break;
        }

        DataText.instance.UpdateDataText();
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
    public void MineForResources(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Stone:
                AddStone(ResourceDivider(DrillData.instance.drill.drillLevel + _extraAddition, _stoneDivider));
                break;
            case ResourceType.Coal:
                AddCoal(ResourceDivider(DrillData.instance.drill.drillLevel + _extraAddition, _coalDivider));
                break;
            case ResourceType.Iron:
                AddIronOre(ResourceDivider(DrillData.instance.drill.drillLevel + _extraAddition, _ironDivider));
                break;
            case ResourceType.Copper:
                AddCopperOre(ResourceDivider(DrillData.instance.drill.drillLevel + _extraAddition, _copperDivider));
                break;
            case ResourceType.Drill:
                MineForResources();
                break;
        }

        DataText.instance.UpdateDataText();
    }

    private int ResourceDivider(float _drillLevel, float _divider)
    {
        return Mathf.CeilToInt(_drillLevel * 2 / _divider);
    }
}
