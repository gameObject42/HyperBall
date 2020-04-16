using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger01 : MonoBehaviour
{
    public Animator anim;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("fall",true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("fall", false);
        }
    }
}
