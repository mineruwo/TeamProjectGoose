using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class Gardener : NPC
{
    public Animator animator;

    private RigBuilder rigBuilder;
    private NavMeshAgent agent;

    public List<NPCState> states;
    public NPCState initState;
    public NPCState currState;

    public Transform keyContainer;
    public Transform key;
    public Transform gardnerTwoHands;
    public Transform gardnerOneHand;
    public float pickUpRange;

    public Transform[] workPos;
    public GameObject goose;

    public bool equipped;
    public bool isArrived;
    public bool isTakenByGoose;

    private States state;
    private int index = 0;

    private void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        StartCoroutine(DoWork());
        //열쇠 떨어뜨렸을 때 체크
        //Vector3 distanceToNPC = transform.position;
        //if(!equipped && distanceToNPC.magnitude <= pickUpRange)
        //{
        //    PickUp();
        //}

        TouchGoose();

        if(index>=workPos.Length)
        {
            index = 0;
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
    public override IEnumerator DoWork()
    {
        yield return new WaitForSeconds(5f);
        Move();

        //pathStatus랑 같을 때 검사 pathComplete
        if(agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            isArrived = true;
            Idle();
            index = 0;
            Debug.Log("걷고있나요?");
        }

        yield break;
    }

    public override void Idle()
    {
        animator.SetFloat("RemainingDistance", 0f);
    }
    public override void Move()
    {
        animator.SetFloat("LocalVelocityZ", 0.5f);
        animator.SetFloat("RemainingDistance", 1f);
        agent.SetDestination(workPos[index].localPosition);
    }

    public override void Chase()
    {
        isTakenByGoose = true;


        //item에다가 nav mesh 달아놓은 다음에 쫓아가게....
        //범위는 얼마 정도?
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
    public override void TouchGoose()
    {
        base.TouchGoose();

        var gooseVec = transform.position - goose.transform.position;
        var backward = transform.forward * -1f;
        var offset = backward - gooseVec;

        float deg = Mathf.Atan2(offset.y, offset.x)*Mathf.Rad2Deg;

        if(deg>45 && gooseVec.y < 1f)
        {
            //if(gooseVec.x > 0f)
            //{
            //    animator.SetFloat("RemainingRotation", -50f);
            //    animator.SetFloat("TurnSpeed", 1f);
            //    agent.transform.LookAt(goose.transform.position);
            //}
            //else if(gooseVec.x < 0f)
            //{
            //    animator.SetFloat("RemainingRotation", 50f);
            //    animator.SetFloat("TurnSpeed", 1f);
            //}
        }

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
