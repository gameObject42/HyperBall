using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //8,9.5,-9    13,-18
    public Transform target;
    private Vector3 offset;

    [Range(0.0f,100.0f)]
    public float smoothNes;

    public bool lookAtPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothNes);
        if (lookAtPlayer)
        {
            transform.LookAt(target);
        }
    }
}
