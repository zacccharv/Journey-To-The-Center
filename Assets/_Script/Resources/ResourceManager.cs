using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int resourceLevel = 1;
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
        ironOre += amount;
        Debug.Log("Iron Ore: " + ironOre);
    }

    public void AddCopperOre(int amount)
    {
        copperOre += amount;
        Debug.Log("Copper Ore: " + copperOre);
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

    public void MineForResources()
    {
        bool foundResource = false;
        // random chance of success
        if (Random.value > 0.5f)
        {
            foundResource = true;
        }

        if (foundResource)
        {
            int resourceType = Random.Range(0, resourceLevel);
            int amount = Random.Range(1, resourceLevel + 1);

            switch (resourceType)
            {
                case 0:
                    AddStone(amount);
                    break;
                case 1:
                    AddCoal(amount);
                    break;
                case 2:
                    AddCopperOre(amount);
                    break;
                case 3:
                    AddIronOre(amount);
                    break;
            }
        }

        DataText.UpdateText();
    }
}
