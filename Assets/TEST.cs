using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private Transform camTr;
    private Rigidbody rb;

    void Start()
    {
        camTr = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");

        var viewPos1 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
        var viewPos2 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 10));
        var viewPosR = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 10));

        var wDir = viewPos2 - viewPos1;
        wDir.y = 0;
        Debug.Log(wDir + " WDirpos");
        wDir.Normalize();
        Debug.Log(wDir + " Normalized");
        var rDir = viewPosR - viewPos1;
        rDir.y = 0; 
        rDir.Normalize();

        rb.velocity = v * wDir * Time.deltaTime * 50f;
        //rb.velocity = h * rDir * Time.deltaTime * 50f;

        //transform.position += v * wDir * Time.deltaTime * 10f;
        //transform.position += h * rDir * Time.deltaTime * 10f;
    }
}
