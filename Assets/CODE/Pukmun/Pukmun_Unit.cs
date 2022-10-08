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

    // Update is called once per frame
    new void Update()
    {
        if (Tools.DistanceToXZ(transform.position,_Target) < .5)
        {
            _Controller.Chill();
        }
    }

    public void UpdateTarget(Vector3 target)
    {
        _Target = target;
        _Controller.SetDirection(target);
        _Controller.SetVelocity();
    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var source = hit.gameObject;

        Debug.Log(source);
        if (source.GetComponent<Player>())
        {
            var manager = FindObjectOfType<Pukmun_Manager>();
            manager.AddPukmun(this);
            Debug.Log($"{this} touched Player");
        }

        else if (source.GetComponentInParent<Whistle>())
        {
            Debug.Log("Whistle Hit");
        }

        
    }
}
