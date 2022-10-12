using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity_Collider : MonoBehaviour
{   
    public List<BoxCollider> BoxCollider;
   
    public void Awake()
    {        
        BoxCollider = GetComponentsInChildren<BoxCollider>().ToList<BoxCollider>();
        BoxCollider.Add(GetComponent<BoxCollider>());
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

    public void Trigger(bool isTrigger)
    {
        BoxCollider.ForEach(x => x.isTrigger = isTrigger);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this} entered {other}");
    }   
}
