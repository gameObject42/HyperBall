using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpwan : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Instantiate(Player);
    }
}
