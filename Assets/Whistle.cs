using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Whistle : MonoBehaviour
{

    public Entity_Animator _Animator;
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

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("WHISTLE");
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