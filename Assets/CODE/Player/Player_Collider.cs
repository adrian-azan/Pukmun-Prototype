using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collider : Entity_Collider
{
    Pukmun_Manager _PM;
    public new void Awake()
    {
        base.Awake();
        
        var test =  GetComponentInParent<Player>();
        _PM = FindObjectOfType<Pukmun_Manager>();
    }

 
    public void OnColliderEnter(Collider hit)
    {
        Debug.Log("Player collider");
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Player Collision with {collision.gameObject}");
        


        var source = collision.gameObject;
        
        if (source.GetComponentInParent<Entity>() == null)
            return;

        if (source.GetComponentInParent<Pukmun_Unit>())
        {
            //_PM.AddPukmun(source.GetComponent<Pukmun_Unit>());
        }

        
    }
   
}
