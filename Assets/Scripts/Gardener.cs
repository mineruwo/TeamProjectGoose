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

    public Transform gardner;
    public Transform keyContainer;
    public Transform gardnerTwoHands;
    public Transform gardnerOneHand;
    public float pickUpRange;

    public GameObject workPos;

    public bool equipped;

    private States state;

    private void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
        agent = GetComponent<NavMeshAgent>();

        //workPos = gameObject.transform.position;
    }
    private void Update()
    {
        Move();

        //���� ����߷��� �� üũ
        Vector3 distanceToNPC = gardner.position - transform.position;
        if(!equipped && distanceToNPC.magnitude <= pickUpRange)
        {
            PickUp();
        }
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

        agent.SetDestination(workPos.transform.position);
    }

    public override void Chase()
    {
        //item���ٰ� nav mesh �޾Ƴ��� ������ �Ѿư���....
        //������ �� ����?
        animator.SetFloat("LocalVelocityZ", 1f);
        animator.SetFloat("RemainingDistance", 1f);
    }

    public override void PickUp()
    {
        base.PickUp();
        equipped = true;
    }

    public override void DropDown()
    {
        base.DropDown();
        equipped = false;
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
