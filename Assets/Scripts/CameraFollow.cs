using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    [Range(0.0f,100.0f)]
    public float smoothNes;

    public bool lookAtPlayer = false;
    void Start()
    {
        StartCoroutine(Checks());   
    }
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = player.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothNes);
            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
    }
    IEnumerator Checks()
    {
        yield return new WaitForSeconds(1);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - player.position;
        }
    }
    IEnumerator follow() {

        yield return new WaitForSeconds(1);
    }
}
