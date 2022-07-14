using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public enum GardenerPos
{
    vase1,
    vase2,
    watering,
    wateringCan,
    shovel,
    spadework,
}

public class Gardener : NPCSet
{
    private RigBuilder rigBuilder;
    
    private NavMeshAgent agent;
    public GameObject[] vasePositions;

    private void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();

        agent = GetComponent<NavMeshAgent>();
        vasePositions = new GameObject[vasePositions.Length];
    }
    private void Update()
    {
        agent.SetDestination(vasePositions[0].transform.position);
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
