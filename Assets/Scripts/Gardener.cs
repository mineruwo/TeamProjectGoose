using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardener : NPCSet
{
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goose"))
        {
            Debug.Log("µµ³ª¾²");
        }
    }
}
