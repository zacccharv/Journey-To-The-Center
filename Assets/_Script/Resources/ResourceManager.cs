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
    [SerializeField] private float _copperDiver = 1.0f;
    private int _amount;

    // [SerializeField] private float _diamondDiver = 1.0f;

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
        _amount = DrillData.instance.drillLevel * 2;

        switch (resourceType)
        {
            case 0:
                break;
            case 1:
                AddStone(ResourceDivider(_stoneDivider));
                break;
            case 2:
                AddCoal(ResourceDivider(_coalDivider));
                break;
            case 3:
                AddIronOre(ResourceDivider(_ironDivider));
                break;
            case 4:
                AddCopperOre(ResourceDivider(_copperDiver));
                break;
        }

        DataText.instance.UpdateResourceText();
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
                AddStone(ResourceDivider(_stoneDivider));
                break;
            case ResourceType.Coal:
                AddCoal(ResourceDivider(_coalDivider));
                break;
            case ResourceType.Iron:
                AddIronOre(ResourceDivider(_ironDivider));
                break;
            case ResourceType.Copper:
                AddCopperOre(ResourceDivider(_copperDiver));
                break;
            case ResourceType.Drill:
                MineForResources();
                break;
        }

        DataText.instance.UpdateResourceText();
    }

    private int ResourceDivider(float _divider)
    {
        return Mathf.RoundToInt(_amount / DrillData.instance.drillLevel * _divider);
    }
}
