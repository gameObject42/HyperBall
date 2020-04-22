using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCharRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.right * 280 * Time.deltaTime);
    }
}
