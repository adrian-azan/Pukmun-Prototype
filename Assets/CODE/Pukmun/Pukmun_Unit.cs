using System.Collections;
using System.Collections.Generic;
using Pukmun.Common.Tools;
using UnityEngine;

public class Pukmun_Unit : Entity
{

    public Vector3 _Target;
    // Start is called before the first frame update
    void Start()
    {
    }

    new void Awake()
    {
        base.Awake();
        Physics.IgnoreLayerCollision(10,10);
    }

    // Update is called once per frame
    new void Update()
    {
        if (_Target != new Vector3(-1,-1,-1) && Tools.DistanceToXZ(transform.position,_Target) < .5)
        {
            _Controller.SetVelocity(0);
        }
    }

    public void UpdateTarget(Vector3 target)
    {
        _Target = target;
        _Controller.SetDirection(target);
        _Controller.SetVelocity();
    }


    public void OnCollisionEnter(Collision hit)
    {
        var source = hit.gameObject;

        Debug.Log(source);
        if (source.GetComponent<Player>() || source.GetComponentInParent<Whistle>() )
        {
            var manager = FindObjectOfType<Pukmun_Manager>();
            manager.AddPukmun(this);
        }                  
    }

    public void OnTriggerEnter(Collider other)
    {
        var manager = FindObjectOfType<Pukmun_Manager>();
        manager.AddPukmun(this);
    }  
}
