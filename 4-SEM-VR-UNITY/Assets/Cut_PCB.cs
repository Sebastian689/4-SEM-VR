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
   
    public Syrebasekar baseScript;
    public Syrebasekar syreScript;
    private bool attached;
    private bool Base = false;
    private bool Syre = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        XRGrab = GetComponent<XRGrabInteractable>();
        Developer = GameObject.Find("Developer");
        Acid = GameObject.Find("AcidTub");
        Dtransform = Developer.transform.Find("Cube.001").GetComponent<SphereCollider>().transform;
        Atransform = Acid.transform.Find("Cube.001").GetComponent<SphereCollider>().transform;
        syreScript = Acid.GetComponent<Syrebasekar>();
        baseScript = Developer.GetComponent<Syrebasekar>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (attached == true && Base == true)
        {
            this.transform.position = Dtransform.position;
        }

        if (attached == true && Syre == true)
        {
            this.transform.position = Atransform.position;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //OnTriggerEnter???
        if (col.gameObject.CompareTag("Developer"))
        {
            attached = true;
            baseScript.isAttached = true;
            baseScript.CheckStatus();
            Base = true;
            Syre = false;
        }

        if (col.gameObject.CompareTag("Acid"))
        {
            attached = true;
            syreScript.isAttached = true;
            syreScript.CheckStatus();
            Base = false;
            Syre = true;

        }
    }

   
}