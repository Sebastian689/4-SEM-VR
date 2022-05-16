using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBProcess : MonoBehaviour
{

    public Collider water;

    private GameObject particles;


    private void Start()
    {
        particles = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == water)
        {
            particles.SetActive(false);
        }
    }
}
