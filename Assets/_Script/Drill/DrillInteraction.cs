using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DrillInteraction : MonoBehaviour
{
    [SerializeField] private Color hoverColor, clickColor;
    private Color _defaultColor;
    private SpriteRenderer _renderer;
    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _defaultColor = _renderer.color;
    }

    void OnMouseEnter()
    {
        _renderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        _renderer.color = _defaultColor;
    }

    void OnMouseDown()
    {
        DrillData.instance.DrillDown(.5f);
        _renderer.color = clickColor;
    }

    void OnMouseUp()
    {
        _renderer.color = hoverColor;
    }
}
