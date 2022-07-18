using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseGrab : MonoBehaviour
{
    public float grabRange = 3f;
    public Transform gooseMouse;
    public GameObject grabObject;
    public Rigidbody rb;
    private Collider collider;
 
    private bool isDrag = false;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            //RaycastHit hit;
            //if(Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
            //{
            //    GrabObject(hit.transform.gameObject);
            //}
            if(grabObject != null)
            {
                isDrag = true;
                Rigidbody grabObjRb = grabObject.GetComponent<Rigidbody>();
                grabObjRb.isKinematic = true;
                grabObjRb.useGravity = false;

                gooseMouse.transform.position = grabObject.GetComponent<TestGrabHandle>().grabHandle.transform.localPosition;

                grabObject.transform.SetParent(gooseMouse);
            }
        }

        //if(grabObject != null)
        //{
        //    grabObject.transform.position = gooseMouse.position;
        //}
    }


    void GrabObject(GameObject grabObj)
    {
        if(grabObj.GetComponent<TestGrabHandle>())
        {
            Rigidbody grabObjRb = grabObj.GetComponent<Rigidbody>();
            grabObjRb.isKinematic = true;
            grabObjRb.useGravity = false;

            gooseMouse.transform.position = grabObj.GetComponent<TestGrabHandle>().transform.localPosition;
            
            grabObj.GetComponent<TestGrabHandle>().transform.SetParent(gooseMouse);


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<TestGrabHandle>())
        {
            grabObject = other.gameObject;
        }
    }

}
