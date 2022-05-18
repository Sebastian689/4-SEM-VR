using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncutPCB : MonoBehaviour
{
    public GameObject PCB_Cutout;

    //Marked out audio indtil videre. Kan kigges på hvis vi får tid.
    //AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //audio = this.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Cutter")) {
            Instantiate(PCB_Cutout,this.gameObject.transform.position, Quaternion.identity);
            //audio.Play();
            this.gameObject.SetActive(false);
        }
    }
}
