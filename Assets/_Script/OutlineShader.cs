using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutlineShader : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public Color outlineColor = Color.white;
    [Range(0, .01f)] public float thickness = 0;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.material.SetColor("_OutlineColor", outlineColor);
    }

    public void Hover()
    {
        if (_renderer.material.HasProperty("_Thickness"))
        {
            _renderer.material.SetFloat("_Thickness", thickness);
            _renderer.material.SetFloat("_OnOff", 1);
        }
    }

    public void Unhover()
    {
        if (_renderer.material.HasProperty("_Thickness"))
        {
            _renderer.material.SetFloat("_Thickness", 0);
            _renderer.material.SetFloat("_OnOff", 0);
        }
    }
}
