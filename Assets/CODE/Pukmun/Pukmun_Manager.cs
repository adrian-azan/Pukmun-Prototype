using System.Collections;
using System.Collections.Generic;
using Pukmun.Common.Tools;
using UnityEngine;

public class Pukmun_Manager : Entity
{
    public List<Vector3> _Points;
    public List<Pukmun_Unit> _Pukmuns;

    public Player _Player;


    public void AddPukmun(Pukmun_Unit pukmun)
    {
        pukmun.GetComponentInChildren<Entity_Controller>().IsTrigger(false);

        if (_Pukmuns.Contains(pukmun) == false)
        {
            _Pukmuns.Add(pukmun);
            Direct();


            Debug.Log($"Added {pukmun}");
        }
        else
        {
            Debug.Log("Already exists");
        }
    }
    
    public new void Awake()
    {
        base.Awake();     
        
        _Player = FindObjectOfType<Player>();

        _Points = new List<Vector3>(100);
        for (int i = 0; i < 100; i++)
        {
            _Points.Add(new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f)));
        }         
        StartCoroutine(Follow());
    }

    public IEnumerator Follow()
    {
        Debug.Log("Following");
        yield return new WaitForSecondsRealtime(.1f);
       

        StartCoroutine(Follow());
        yield return null;

    }    

    public void Direct()
    {
        Vector3 parentFlat = transform.position;
        parentFlat.y = 0;        

        for (int i = 0; i < _Pukmuns.Count; i++)
        {
            _Pukmuns[i].UpdateTarget(_Points[i] + parentFlat);
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {

     //   Debug.DrawLine(transform.position, _Player.transform.position,Color.red);
        if (Tools.DistanceToXZ(_Player.transform, transform) > 5)
        {
            _Controller.SetDirection(_Player);
            _Controller.SetVelocity(.2f);

          // Direct();
        }
        else
            _Controller.SetVelocity(0);
             
        //_Points.ForEach(point => Debug.DrawLine(transform.position, parentFlat + point));
    }
}
