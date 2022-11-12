using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pukmun.Common.Tools;


public class Camera : Entity
{    


    private CameraStateMachine _Target;

    public void Awake()
    {
        base.Awake();
        _Controller.SetGravity(0);
        _Target = FindObjectOfType<CameraStateMachine>();
    }

    public void FixedUpdate()
    {
           if (Tools.DistanceToXZ(transform,_Target.transform) < .5)
        {
            _Controller.SetVelocity(0);
        }
        else { 
        _Controller.SetDirection(_Target.transform.position);
        _Controller.SetVelocity();
        }
    }



}
