using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity_Skin : MonoBehaviour
{
    private List<Renderer> _Render;

    private void Awake()
    {
        _Render = GetComponentsInChildren<MeshRenderer>().ToList<Renderer>();           
    }

    public void Disable()
    {
        if (_Render == null)
            return;
        _Render.ForEach(x => x.enabled = false);
    }

    public void Enable()
    {
        if (_Render == null)
            return;
        _Render.ForEach(x => x.enabled = true);
    }

    public void SetColor(Color color)
    {
        _Render.ForEach(r => r.material.color = color);
    }   
}
