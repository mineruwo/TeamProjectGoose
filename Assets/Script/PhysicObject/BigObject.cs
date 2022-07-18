using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigObject : PhysicObject
{
    public Vector3 setPos;
    private Rigidbody Rigidbody;
    private List<Collider> colliders;

    public void Awake()
    {
        setPos = transform.position;
        Rigidbody = GetComponent<Rigidbody>();
        var cols = GetComponents<Collider>();
        foreach (var col in cols)
        {
            col.enabled = false;
            colliders.Add(col);
        }

        isActive = false;
        isHeavy = true;
        isSound = false;
        isGrab = true;
    }

    public override bool OnGrab(bool isgrab)
    {
        switch (isgrab)
        {
            case true:
                foreach (var col in colliders)
                {
                    col.enabled = true;
                }
                isActive = true;

                return true;

            case false:

                foreach (var col in colliders)
                {
                    col.enabled = false;
                }

                return false;
        }

    }

    public override bool OnTrigger()
    {
        return true;
    }
}
