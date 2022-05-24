using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncutPCB : MonoBehaviour
{
    public GameObject Cut_PCB;

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
            Instantiate(Cut_PCB, new Vector3(-0.638599992f,1.63199997f,-3.26169991f), Quaternion.Euler(270.019775f,0f,0f));
            //audio.Play();
            gameObject.SetActive(false);
        }
    }
}
