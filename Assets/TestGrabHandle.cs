using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrabHandle : MonoBehaviour
{
    public GameObject grabHandle;
    private Vector3 distance;
    private FixedJoint joint;
    public Rigidbody gooseRb;
    public Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); 
        distance = transform.position - grabHandle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabHandle()
    {
        joint = new FixedJoint();
        joint.connectedBody = rigidBody;
    }

    
}
