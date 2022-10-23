using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Whistle : Entity
{

    public PlayerInput _Pad;


    // Start is called before the first frame update
    private void Awake()
    {
        _Animator = GetComponent<Entity_Animator>();
        _Pad = GetComponent<PlayerInput>();
        _Pad.SwitchCurrentActionMap("Whistle");
        _Pad.SwitchCurrentControlScheme("GamePad", Gamepad.current);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WHISTLE HIT");
    }

    public void OnWhistle(InputValue input)
    {
        if (input.isPressed && _Animator.IsState("Idle",0))
        {
            _Animator.Play("UseWhistle");
        }
            
        else if (!input.isPressed && !_Animator.IsState("Idle",0))
        {
            _Animator.Stop();
        }
    }
}
