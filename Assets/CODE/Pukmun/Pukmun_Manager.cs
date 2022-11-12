using System.Collections;
using System.Collections.Generic;
using Pukmun.Common.Tools;
using UnityEngine;

public class Pukmun_Manager : Entity
{
    public List<Vector3> _Points;
    public List<Pukmun_Unit> _Pukmuns;

    public Player _Player;

    public GameObject PukmanPrefab;

    public Pukmun_Unit PopPukmun()
    {
        if (_Pukmuns.Count <= 0)
            return null;

        var sacrafice = _Pukmuns[0];
        _Pukmuns.RemoveAt(0);
         _Player._Collider.IgnoreCollision(sacrafice._Collider,false);

        sacrafice.SnapTo(_Player.transform.position + Vector3.forward);
        sacrafice.RotateAround(_Player.transform.position, Vector3.up, 180);

        return sacrafice;        
    }
     
    public void AddPukmun(Pukmun_Unit pukmun)
    {
        _Player._Collider.IgnoreCollision(pukmun._Collider);

        if (_Pukmuns.Contains(pukmun) == false)
        {
            _Pukmuns.Add(pukmun);
            Direct();          
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
         

         for (int i = 0; i < 100; i++)
        {

           Instantiate(PukmanPrefab,new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f)),new Quaternion());
        
        }   

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

            Direct();
        }
        else
            _Controller.SetVelocity(0);
             
        //_Points.ForEach(point => Debug.DrawLine(transform.position, parentFlat + point));
    }
}
