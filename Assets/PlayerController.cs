using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 heading = Vector3.zero;
        heading.z = Mathf.Abs(cam.transform.forward.z);
        heading.y = 0;
        heading.Normalize();
        //test code
        if (Input.GetKey(KeyCode.W))
        {
            //  rb.velocity = cam.transform.forward.normalized ;
            rb.velocity = heading;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = cam.transform.right.normalized * -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = heading * -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = cam.transform.right.normalized;
        }
        Debug.Log(rb.velocity);

    }
}
