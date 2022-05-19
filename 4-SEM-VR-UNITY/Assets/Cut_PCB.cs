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
    private bool attached;
    
   
    // Start is called before the first frame update
    void Start()
    {
        XRGrab = GetComponent<XRGrabInteractable>();
        Developer = GameObject.Find("Developer");
        Acid = GameObject.Find("AcidTub");
        Dtransform = Developer.transform.Find("Cube.001").gameObject.transform;
        Atransform = Acid.transform.Find("Cube.001").gameObject.transform;
        GSpot = Developer.transform.Find("Cube.001").gameObject.GetComponent<SphereCollider>();
        script = Developer.GetComponent<Syrebasekar>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (attached == true)
        {
            this.transform.position = Dtransform.position;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //OnTriggerEnter???
        if (col.gameObject.CompareTag("Developer"))
        {
            attached = true;
            script.isAttached = true;
            script.CheckStatus();
   
        }
    }
}