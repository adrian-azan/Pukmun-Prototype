using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pukmun.Common.Tools;


public class Camera : Entity
{    


 //   private CameraStateMachine _Target;
    private Transform _Target;
    private float t;

    public void Awake()
    {
        base.Awake();
        _Controller.Disable();

        _Controller.SetGravity(0);
        _Target = FindObjectOfType<CameraStateMachine>().transform;

        t = 0.0f;
    }

    public void FixedUpdate()
    {
        if (Tools.DistanceToXZ(transform,_Target) > .5)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,_Target.position.x,t),
                Mathf.Lerp(transform.position.y,_Target.position.y,t),
                Mathf.Lerp(transform.position.z,_Target.position.z,t));

            
            transform.rotation = Quaternion.Slerp(transform.rotation, _Target.rotation,t); 
              
            t += .01f * Time.deltaTime;

        }

        else
            t = 0;



        /*if (Tools.DistanceToXZ(transform,_Target.position.transform) < .5)
        {
            _Controller.SetVelocity(0);
        }
        else
        { 
            _Controller.SetDirection(_Target.position.transform.position);
            _Controller.SetVelocity();
                _Controller.SetGravity(-1);
        
        }*/
    }



}
