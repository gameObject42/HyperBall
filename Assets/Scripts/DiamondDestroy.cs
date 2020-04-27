using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDestroy : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
