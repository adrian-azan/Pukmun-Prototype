using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pukmun.Common.Tools;


public class Camera : Entity
{    


 //   private CameraStateMachine _Target;
    private Transform _Target;
    public Transform _Orientation;
    private float t;

    public Transform[] corners;
    public int index = 0;
    
    public void Awake()
    {
        base.Awake();
        _Controller.Disable();
        
        
        

        _Controller.SetGravity(0);
        _Target = FindObjectOfType<CameraStateMachine>().transform;
       

       // _Orientation.position = _Target.position - transform.position;

        t = 0.0f;
    }

    public void FixedUpdate()
    { 
        
        transform.position = new Vector3(Mathf.Lerp(corners[index].position.x,corners[index+1].position.x,t),
                Mathf.Lerp(corners[index].position.y,corners[index+1].position.y,t),
                Mathf.Lerp(corners[index].position.z,corners[index+1].position.z,t));

         transform.rotation = Quaternion.Slerp(corners[index].rotation, corners[index+1].rotation,t); 

        t += .5f * Time.deltaTime;

        if (t >= 1.2)
        {
            t = 0;
            index = (index+1)%3;
          }

        _Orientation = transform;
        //_Orientation.rotation = new Quaternion(_Orientation.rotation.y,0,_Orientation.rotation.z,_Orientation.rotation.w);
   /*     if (Tools.DistanceToXZ(transform,_Target) > .5)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,_Target.position.x,t),
                Mathf.Lerp(transform.position.y,_Target.position.y,t),
                Mathf.Lerp(transform.position.z,_Target.position.z,t));

            
            transform.rotation = Quaternion.Slerp(transform.rotation, _Target.rotation,t); 
              
            t += .01f * Time.deltaTime;

        }

        else
            t = 0;

        */

    }



}
