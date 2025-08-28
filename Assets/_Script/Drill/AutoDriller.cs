using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AutoDriller : MonoBehaviour
{
    public ResourceType resourceType = ResourceType.Nothing;
    public float drillInterval = 1.0f; // Time in seconds between each automatic drill action
    private float drillTimer = 4.0f;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color drillColor;
    [SerializeField] private float drillColorDuration = 0.2f;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        drillTimer += Time.deltaTime;

        if (drillTimer >= drillInterval)
        {
            drillTimer = 0.0f;
            ResourceManager.instance.MineForResources(resourceType);
            StartCoroutine(BrieflyChangeColor(drillColor, drillColorDuration));
        }
    }

    public void SetDrillParameters(float interval)
    {
        drillInterval = interval;
    }

    // Coroutine to briefly change color on mine
    private IEnumerator BrieflyChangeColor(Color targetColor, float duration)
    {
        Color originalColor = _spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _spriteRenderer.color = targetColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _spriteRenderer.color = originalColor;
    }
}
