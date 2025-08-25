using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void AddIronOre(int amount)
    {
        ironOre += amount * DrillData.instance.drillLevel / 4;
        Debug.Log("Iron Ore: " + ironOre);
    }

    public void AddCopperOre(int amount)
    {
        copperOre += amount * DrillData.instance.drillLevel / 3;
        Debug.Log("Copper Ore: " + copperOre);
    }

    public void AddCoal(int amount)
    {
        coal += amount * DrillData.instance.drillLevel / 2;
        Debug.Log("Coal: " + coal);
    }

    public void AddStone(int amount)
    {
        stone += amount * DrillData.instance.drillLevel;
        Debug.Log("Stone: " + stone);
    }

    public void MineForResources()
    {

        int resourceType = Random.Range(0, DrillData.instance.drillLevel + 1);
        int amount = Random.Range(1, DrillData.instance.drillLevel + 1);

        switch (resourceType)
        {
            case 0:
                break;
            case 1:
                AddStone(amount);
                break;
            case 2:
                AddCoal(amount);
                break;
            case 3:
                AddIronOre(amount);
                break;
            case 4:
                AddCopperOre(amount);
                break;
        }

        DataText.UpdateResources();
    }
}
