using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncutPCB : MonoBehaviour
{
    public GameObject PCB_Cutout;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();

        PCB_Cutout = GameObject.FindGameObjectWithTag("PCBCutout");
        PCB_Cutout.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Cutter")) {
            PCB_Cutout.SetActive(true);
            audio.Play();
            this.gameObject.SetActive(false);
        }
    }
}
