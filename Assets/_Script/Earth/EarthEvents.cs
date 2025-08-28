using UnityEngine;

public class EarthEvents : MonoBehaviour
{
    public float eventInterval = 5;
    public int explosivenessIncreaseAmount = 5;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= eventInterval)
        {
            EarthData.instance.IncreaseExplosiveness(explosivenessIncreaseAmount);
            DataText.instance.earthDataText.UpdateText();
            timer = 0f;
        }
    }
}
