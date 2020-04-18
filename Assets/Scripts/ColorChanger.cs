using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject[] Obs;
    public Color myColor;

    private void Start()
    {
        
    }
    public void Update()
    {
        Obss();
    }
    public void Obss()
    {
        Obs = GameObject.FindGameObjectsWithTag("Obstacle");
    }
    public void ChangeColor()
    {
        myColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < Obs.Length; i++)
        {
            Obs[i].GetComponent<MeshRenderer>().material.color = myColor;
        }
        
    }
}
