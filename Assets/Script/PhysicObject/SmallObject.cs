using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObject : PhysicObject
{
    public Vector3 setPos;
    private Rigidbody Rigidbody;
    private List<Collider> colliders;
    public GameObject handlePoint;

    public void Awake()
    {
        setPos = transform.position;
        Rigidbody = GetComponent<Rigidbody>();
        var cols = GetComponentsInChildren<Collider>();
        foreach (var col in cols)
        {
            colliders.Add(col);
            col.enabled = false;
        }

        isActive = false;
        isHeavy = false;
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
