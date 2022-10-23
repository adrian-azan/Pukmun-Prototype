using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity_Collider : MonoBehaviour
{   
    public List<Collider> BoxCollider;
   
    public void Awake()
    {        
        BoxCollider = GetComponentsInChildren<Collider>().ToList<Collider>();
       
    }

    public void Disable()
    {
        if (BoxCollider == null)
            return;
        BoxCollider.ForEach(x => x.enabled = false);
    }

    public void Enable()
    {
        if (BoxCollider == null)
            return;
        BoxCollider.ForEach(x => x.enabled = true);
    }

    public void IgnoreCollision(Entity_Collider collider, bool ignore = true)
    {

        Debug.Log("Ignoring");
        foreach (var box in BoxCollider)
        {
            foreach (var otherBox in collider.BoxCollider)
            {
                Physics.IgnoreCollision(box,otherBox, ignore);
            }
        }
       // BoxCollider.ForEach(box => collider.BoxCollider.ForEach( otherBox => Physics.IgnoreCollision(box,otherBox,ignore)));
    }


    public void Trigger(bool isTrigger)
    {
        BoxCollider.ForEach(x => x.isTrigger = isTrigger);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this} entered {other}");
    }   
}
