using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;


public class Cut_PCB : MonoBehaviour
{
    private XRGrabInteractable XRGrab;
    public GameObject Developer;
    public GameObject Acid;
    public Transform Dtransform;
    public Transform Atransform;
    public SphereCollider GSpot;
    public Syrebasekar script;
    
   
    // Start is called before the first frame update
    void Start()
    {
        XRGrab = GetComponent<XRGrabInteractable>();
        Developer = GameObject.Find("Developer");
        Acid = GameObject.Find("AcidTub");
        Dtransform = Developer.transform.Find("Cube.001").gameObject.transform;
        Atransform = Acid.transform.Find("Cube.001").gameObject.transform;
        GSpot = Developer.transform.Find("Cube.001").gameObject.GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        //OnTriggerEnter???
        if (col.gameObject.CompareTag("Developer"))
        {
            XRGrab.enabled = false;
            this.transform.position = Dtransform.position;
            this.GetComponent<BoxCollider>().enabled = false;
            script.CheckStatus();
        }
    }
}