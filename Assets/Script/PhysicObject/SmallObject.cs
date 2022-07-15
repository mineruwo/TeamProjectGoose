using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObject : PhysicObject
{

    public Vector3 setPos;

    public void Start()
    {
        setPos = transform.position;
    }

    public override bool OnGrab()
    {
        throw new System.NotImplementedException();
    }

    public override bool OnTrigger()
    {
        throw new System.NotImplementedException();
    }
}
