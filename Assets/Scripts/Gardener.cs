using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class Gardener : NPCState
{
    public Animator animator;

    private RigBuilder rigBuilder;
    private NavMeshAgent agent;

    public List<NPCState> states;
    public NPCState initState;
    public NPCState currState;

    private States state;

    private void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //agent.SetDestination(destinations);]
        Move();
    }
    public override void Detect()
    {
        rigBuilder.layers[0].active = true;
    }
    public override void Undetect()
    {
        rigBuilder.layers[0].active = false;
    }
    public override void DoWork()
    {
        base.DoWork();
        
    }

    public override void Idle()
    {
        base.Idle();
        animator.SetFloat("RemainingDistance", 0f);
    }
    public override void Move()
    {
        animator.SetFloat("LocalVelocityZ", 0.5f);
        animator.SetFloat("RemainingDistance", 1f);
    }

    public override void Chase()
    {
        //item에다가 nav mesh 달아놓은 다음에 쫓아가게....
        //범위는 얼마 정도?
        animator.SetFloat("LocalVelocityZ", 1f);
        animator.SetFloat("RemainingDistance", 1f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goose"))
        {
            Detect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goose"))
        {
            Undetect();
        }
    }
}
