using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DrillInteraction : MonoBehaviour
{
    public DrillData drillData;
    [SerializeField] private Color hoverColor, clickColor;
    private Color _defaultColor;
    private Renderer _renderer;
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    void OnMouseEnter()
    {
        _renderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }

    void OnMouseDown()
    {
        drillData.DrillDown(drillData.drillPower);
        _renderer.material.color = clickColor;
    }

    void OnMouseUp()
    {
        _renderer.material.color = hoverColor;
    }
}
