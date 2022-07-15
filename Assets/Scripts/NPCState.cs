using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    idle,
    move,
    work,
    chase,
}
public class AiCondition
{
    public virtual bool detectGoosehasItem()
    {
        return false;
    }

    public virtual bool detectObjectOn()
    {
        return false;
    }

    public virtual bool outOfSight()
    {
        return false;
    }
}

public class Transition
{
    public AiCondition condition;
    public NPCState target;
}
public class NPCState : MonoBehaviour 
{
    List<Transition> transitions = new List<Transition>();
    private void Awake()
    {
        
    }
    public void OnEnable()
    {
        
    }

    public void OnDisable()
    {
        
    }

    public virtual void DoWork()
    {
    }
    public virtual void Detect()
    {
    }
    public virtual void Idle()
    {
    }
    public virtual void Undetect()
    {
    }
    public virtual void Chase()
    {
    }
    public virtual void Move()
    {
    }
}
