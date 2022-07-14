using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class Gardener : NPCSet
{
    private RigBuilder rigBuilder;
    public GameObject rig;

    private void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
        rigBuilder.layers[0].active = false;
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
