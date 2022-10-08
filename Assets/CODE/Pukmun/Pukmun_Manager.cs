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
        yield return new WaitForSecondsRealtime(1);
         if (Tools.DistanceToXZ(_Player.transform, transform) > 5)
        {
            _Controller.SetDirection(_Player);
            _Controller.SetVelocity();

          // Direct();
        }
        else
            _Controller.Chill();

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
        base.Update();

        Debug.DrawLine(transform.position, _Player.transform.position,Color.red);
       
        Debug.DrawRay(transform.position, _Controller._Velocity*_Controller._Speed, Color.magenta);

        Vector3 parentFlat = transform.position;
        parentFlat.y = 0;
        //_Points.ForEach(point => Debug.DrawLine(transform.position, parentFlat + point));


        Debug.DrawRay(transform.position, _Controller._Controller.velocity*3, Color.yellow);

    }
}
