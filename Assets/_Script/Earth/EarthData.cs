using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthData : MonoBehaviour
{
    public static EarthData instance;

    /// <summary>
    /// The current health of the Earth. If it reaches zero, the game is over.
    /// </summary>
    public int earthHealth = 100;

    /// <summary>
    /// The current explosiveness of the Earth. If it reaches a certain threshold, an event is triggered?
    /// </summary>
    public int explosiveness = 0;

    private void Awake()
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

    public void DamageEarth(int amount)
    {
        earthHealth -= amount;
        if (earthHealth <= 0)
        {
            // Trigger game over event
            Debug.Log("The Earth has been destroyed!");
        }
    }

    public void IncreaseExplosiveness(int amount)
    {
        explosiveness += amount;
        if (explosiveness >= 100)
        {
            // Trigger eruption event
            Debug.Log("The Earth is erupting!");
            DamageEarth(10); // Example damage value
            explosiveness = 0; // Reset explosiveness after eruption
        }
    }
}
