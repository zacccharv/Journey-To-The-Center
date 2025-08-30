using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(OutlineShader))]
public class DrillInteraction : MonoBehaviour
{
    public float clickSize = 1.025f;
    public float drillAmount = 1.00f;
    private OutlineShader outlineShader;

    void Awake()
    {
        outlineShader = GetComponent<OutlineShader>();
    }

    void OnMouseEnter()
    {
        outlineShader.Hover();
    }

    void OnMouseExit()
    {
        outlineShader.Unhover();
    }

    void OnMouseDown()
    {
        DrillData.instance.drill.DrillDown(drillAmount);
        transform.localScale = Vector3.one * clickSize;
    }

    void OnMouseUp()
    {
        transform.localScale = Vector3.one;
    }
}
