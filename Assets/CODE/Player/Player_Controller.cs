using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : Entity_Controller
{
    public Animator _Animator;
    public Vector3 _Facing ;
    private Vector3 _Vel;
    public PlayerInput _Pad;
    private Player _Player;
    
    new void Awake()
    {
        base.Awake();
        _Animator = GetComponentInParent<Animator>();  
        _Player = GetComponentInParent<Player>();
        _Pad = GetComponent<PlayerInput>();
        _Pad.SwitchCurrentActionMap("Player");
        _Pad.SwitchCurrentControlScheme("GamePad", Gamepad.current);

        Debug.Log(_Pad);
        
        if (_Pad == null)
            Debug.Log("Not Connected");
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();   

        Debug.DrawRay(transform.position, _Facing*-1,Color.red);
    }        

    public void OnDash(InputValue input)
    {       
        _Animator.Play("Dash");
    }

    


    public void OnTEST(InputValue input)
    {
    }

    public void OnLockDown(InputValue input)
    { 
        if (input.isPressed)
            _Pad.SwitchCurrentActionMap("Aiming");
        else
            _Pad.SwitchCurrentActionMap("Player");
    }

  

    public void OnMove(InputValue input)
    {
        _Vel = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y); 

        if (_Facing == Vector3.zero && _Vel != Vector3.zero)
        { 
            SetDirection(transform.position + _Vel);
            Turn(_Vel);
        }
        
        if (_Vel.magnitude < .3f)
            _Vel = Vector3.zero;

        SetDirection(_Vel+transform.position);     
        //Debug.Log($"OnMove {_Vel}");
        if (_Vel.x == 0 && _Vel.z == 0)
            SetVelocity(0);
        else
            SetVelocity(_Vel);  
    }

    public void OnLook(InputValue input)
    {
        Vector2 facing = input.Get<Vector2>();
        
        _Facing = new Vector3(facing.x,0,facing.y);

        //Debug
        facing = new Vector3(facing.x, 1, facing.y);
        Debug.DrawLine(transform.position, facing*3, Color.green);

        Debug.Log($"transform+Facing = {transform.position + _Facing*3}");
        SetDirection(transform.position + _Facing*3);
        Turn(_Facing);
    }
}
