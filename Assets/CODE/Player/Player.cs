using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
 using System.Linq;


public class Player : Entity
{
    public Vector3 _LastDirection;
    public Light _Light;
    public Vector3 _Facing;  
    

    public new void Awake()
    {       
        _Controller = GetComponentInChildren<Player_Controller>(); 
    } 
}
