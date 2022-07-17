using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseGrab : MonoBehaviour
{
    public float grabRange = 3f;
    public Transform gooseMouse;
    public GameObject grabObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
            {
                GrabObject(hit.transform.gameObject);

            }
        }

        if(grabObject != null)
        {
            grabObject.transform.position = gooseMouse.position;
        }
    }

    


    void GrabObject(GameObject grabObj)
    {
        if(grabObj.GetComponent<Rigidbody>())
        {
            Rigidbody grabObjRb = grabObj.GetComponent<Rigidbody>();
            grabObjRb.useGravity = false;
            grabObjRb.drag = 10;

            grabObject = grabObj;
        }
    }
}
