using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

public class Entity : MonoBehaviour
{
    public Entity_Collider _Collider;
    public Entity_Skin _Skin;
    public Entity_Controller _Controller;
    public Entity_Animator _Animator;

    public float _Health;


    public void Disable()
    {     
        _Collider?.Disable();      
        _Skin?.Disable();        
        _Controller?.Disable();       
        _Animator?.Disable();     
    }

    public void Enable()
    {       
        _Collider?.Enable();      
        _Skin?.Enable();       
        _Controller?.Enable();
        _Animator?.Enable();
    }


    public void Awake()
    {
        _Collider = GetComponentInChildren<Entity_Collider>();
        _Skin = GetComponentInChildren<Entity_Skin>();
        _Controller = GetComponentInChildren<Entity_Controller>();
        _Animator = GetComponent<Entity_Animator>();
        _Health = _Health == 0 ? Mathf.Infinity : _Health;
    }
          
    public void SnapTo(Vector3 newPosition)
    {
        _Controller?.Disable();
        transform.position = newPosition;
        _Controller?.Enable();
    }

    public void RotateAround(Vector3 point, Vector3 axis, float angle)
    {
        _Controller?.Disable();
        transform.RotateAround(point, axis, angle);
        _Controller?.Enable();       
    }
}
