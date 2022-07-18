using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    Vector3 cameraPosition = new Vector3(0, 0, -15);

    public Transform player;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
