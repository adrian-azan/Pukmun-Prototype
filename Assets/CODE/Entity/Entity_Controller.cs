using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity_Controller : MonoBehaviour
{
    public Rigidbody _Controller;
    public Vector3 _Velocity;
    public float _Speed;
    public float _Gravity;
    public bool _Fly;
    protected float _Direction;
    public Vector3 _Target;
    
    public void Disable()
    {
        if (_Controller == null)
            return;
        _Controller.isKinematic = true;
    }

    public void Enable()
    {
        if (_Controller == null)
            return;
        _Controller.isKinematic = false;
    }

    public void IsTrigger(bool isTrigger)
    {
        _Controller.detectCollisions = isTrigger;
    }

    protected void Awake()
    {
        _Controller = GetComponentInParent<Entity>().GetComponentInChildren<Rigidbody>();
        _Velocity = Vector3.zero;
        _Gravity = 0.05f;
    }
  
    protected void FixedUpdate()
    {
        Gravity(_Gravity);          
        if (_Controller?.isKinematic ==false)
            _Controller.velocity =_Velocity / Time.fixedDeltaTime;

    }

    public void Chill()
    {
        SetVelocity(0);
    }

    public void SetSpeed(float speed)
    {
        if (speed < 0)
            return;
        _Speed = speed;
    }

    public void SetGravity(float gravity)
    {
        _Gravity = gravity;
    }

    public void SetVelocity(float scale = 1)
    {
        _Velocity = new Vector3(1F, _Velocity.y, 1F);
        _Velocity.x = -_Velocity.x * Mathf.Cos(_Direction) * scale * _Speed;
        _Velocity.z = _Velocity.z * Mathf.Sin(_Direction) * scale * _Speed;  
    }

    public void SetVelocity(Vector3 velocity)
    {
        _Velocity = velocity*_Speed;
    }    

     public void Turn(Vector3 dir, float step = 10)
    {   
        if (dir == Vector3.zero)
            return;

        var angle = Quaternion.RotateTowards(_Controller.transform.rotation,Quaternion.LookRotation(dir,Vector3.up),step);        
        _Controller.MoveRotation(Quaternion.Euler(new Vector3(0,_Direction,0)));
    }      

    

     public void SetDirection(float angle)
    {     
        _Direction = angle;    
        Debug.Log($"{_Direction} degrees");
    }



     public void SetDirection(Entity target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 directionToTarget = _Controller.transform.position - targetPosition;
        float angle = Vector3.SignedAngle(Vector3.right, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }sadfsdaf
    public void SetDirection(Vector3 target)
    {        
        Debug.Log($"{_Controller.transform.position} - {target} = {_Controller.transform.position - target}");
        Vector3 directionToTarget = _Controller.transform.position - target;
        directionToTarget.y = 0;
        float angle = Vector3.SignedAngle(Vector3.right, directionToTarget, Vector3.up) + 180;
        SetDirection(angle);
    }
   
     public void Gravity(float scale = 1)
     {        
        if (_Fly)
            return;
        
        else
            _Velocity.y = (Physics.gravity.y * scale);        
     }
}
