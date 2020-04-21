using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.startGame == true)
        {
            transform.Rotate(Vector3.right * 860 * Time.deltaTime, Space.Self);
        }
    }
}
