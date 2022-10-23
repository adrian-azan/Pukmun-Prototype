using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Controller : MonoBehaviour
{
    private Rigidbody _Controller;
    private Vector3 _Velocity;
    private float _Direction;

    [SerializeField]
    private float _Speed;
    
    [SerializeField]
    private float _GravityScale; 
    
    [SerializeField]
    private bool _Fly;
    
    protected void Awake()
    {
        _Controller = GetComponentInParent<Entity>().GetComponentInChildren<Rigidbody>();
        _Velocity = Vector3.zero;
        _Direction = 0;
    }
  
    protected void FixedUpdate()
    {
        Gravity();          
        if (_Controller?.isKinematic ==false)
            _Controller.velocity = (_Velocity * Time.fixedDeltaTime)*100;
    }


    public void SetGravity(float gravity)
    {
        _GravityScale = gravity;
    }

    public void SetSpeed(float speed)
    {
        if (speed < 0)
            return;
        _Speed = speed;
    }       

    /*
     * Set the velocity based on the entities direction
     */
    public void SetVelocity(float scale = 1)
    {
        _Velocity = new Vector3(1F, _Velocity.y, 1F);
        _Velocity.x = -_Velocity.x * Mathf.Cos(Mathf.Deg2Rad * _Direction) * scale * _Speed;
        _Velocity.z = _Velocity.z * Mathf.Sin(Mathf.Deg2Rad * _Direction) * scale * _Speed;  
    }

    /*
     * Set the velocity based on an externally calculated velocity
     */
    public void SetVelocity(Vector3 velocity)
    {
        _Velocity = velocity*_Speed;
    }    

    /*
     * Sets the direction of the entity, to be used when
     * setting the velocity
     */
    public void SetDirection(float angle)
    {     
        _Direction = angle;           
    }
           
    public void SetDirection(Vector3 target)
    {                
        Vector3 directionToTarget = target - transform.position;  
        directionToTarget.y = 0;
        
        //Why Vector3.left? Because it worked
        float angle = Vector3.SignedAngle(Vector3.left,directionToTarget, Vector3.up);
        SetDirection(angle);
    }

    public void SetDirection(Entity target)
    {        
        SetDirection(target.transform.position);       
    }



    /*
     * Turn will physically rotate the entity 
     * in the world space. 
     */
     public void Turn(Vector3 dir, float step = 45)
     {   
        if (dir == Vector3.zero)
            return;

        var angle = Quaternion.RotateTowards(_Controller.transform.rotation,Quaternion.LookRotation(dir,Vector3.up),step);        
        _Controller.MoveRotation(angle);
     }      
   
    /*
     * Entities do not use the automatic Unity physics gravity. We 
     * apply gravity in our own function to give us better
     * control over each entity.
     */
     public void Gravity()
     {        
        if (_Fly || _Velocity.y < Physics.gravity.y)
            return;   

        _Velocity.y += Physics.gravity.y * Time.fixedDeltaTime;        
     }   




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
}
