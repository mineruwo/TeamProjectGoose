using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private Transform camTr;
    private Rigidbody rb;

    public float curspeed = 2;
    public float maxSpeed = 10;

    private Vector3 dir;
    private bool input = false;
    private Quaternion targetRot;
    void Start()
    {
        camTr = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxisRaw("Vertical");
        var h = Input.GetAxisRaw("Horizontal");
        Debug.Log(v);
        input = v != 0f || h != 0f;

        var viewPos1 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
        var viewPos2 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 10));
        var viewPosR = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 10));

        var wDir = viewPos2 - viewPos1;
        wDir.y = 0;
        wDir.Normalize();

        var rDir = viewPosR - viewPos1;
        rDir.y = 0;
        rDir.Normalize();

        dir = v * wDir + h * rDir;
        dir.Normalize();

        if (rb.velocity.magnitude > 0.1f)
        {
            targetRot = Quaternion.LookRotation(rb.velocity);
        }

        if (input)
        { 
           transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
        //rb.velocity = h * rDir * Time.deltaTime * 50f;

        //transform.position += v * wDir * Time.deltaTime * 10f;
        //transform.position += h * rDir * Time.deltaTime * 10f;
    }

    private void FixedUpdate()
    {
        if (input)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(dir * curspeed);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime * 10f);
        }
        
    }
}
