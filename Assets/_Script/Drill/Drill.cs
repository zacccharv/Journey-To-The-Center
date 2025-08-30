using UnityEngine;

public class Drill : MonoBehaviour
{
    public float drillDepth = 0.0f;
    public float drillLevel = 1.0f;
    public float drillPower = 0.25f; // Amount of resource mined per action
    public ParticleSystem winConfetti;
    public const float centerOfTheEarthMeters = 6371000f;

    public void DrillDown(float amount)
    {
        drillDepth += amount * drillPower;
        drillDepth = Mathf.Round(drillDepth * 100f) / 100f; // Round to 2 decimal places
        ResourceManager.instance.MineForResources();

        if (drillDepth >= centerOfTheEarthMeters)
        {
            drillDepth = centerOfTheEarthMeters;
            WinTheGame();
        }
    }

    public void UpgradeDrill()
    {
        drillLevel++;
        drillPower *= 1.2f; // Increase amount of resource mined per action by 20%
        winConfetti.Play();
    }

    public void WinTheGame()
    {
        Debug.Log("You have reached the center of the Earth!");
        winConfetti.Play();
    }
}