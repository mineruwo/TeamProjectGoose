using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicObject : MonoBehaviour
{

    private bool isGrab;

    private bool isSound;

    private bool isHeavy;

    private bool isActive;
    public abstract bool OnTrigger();

    public abstract bool OnGrab();

}
