using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : MonoBehaviour
{
    public class CameraState
    {
        public CameraState(Vector3 pos, Vector3 rot)
        {
            _Pos = pos;
            _Rot = rot;
        }

        public Vector3 _Pos;
        public Vector3 _Rot;
    }


    public Player _PLAYER_DEBUG;

    public void Awake()
    {
        _PLAYER_DEBUG = FindObjectOfType<Player>();
    }

    public void Update()
    {
        Debug.DrawLine(transform.position, _PLAYER_DEBUG.transform.position);
    }

}
