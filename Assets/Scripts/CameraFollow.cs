using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //8,9.5,-9    13,-18
    //public GameObject player;
    private Transform player;
    private Vector3 offset;

    [Range(0.0f,100.0f)]
    public float smoothNes;

    public bool lookAtPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Checks", 1.0f);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            Vector3 newPos = player.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothNes);
            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
    }
    public void Checks()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - player.position;
        }
    }
}
