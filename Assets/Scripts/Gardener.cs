using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardener : NPCSet
{
    Animator animator;
    public BoxCollider col;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Detect()
    {
    }
    public override void DoWork()
    {
        base.DoWork();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goose"))
        {
            Debug.Log("»§");
        }
    }
}
