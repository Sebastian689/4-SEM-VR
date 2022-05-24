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

    GameObject _gameManager;
   
    public Syrebasekar baseScript;
    public Syrebasekar syreScript;
    public PCBCutout cutoutScript;
    [SerializeField]
    bool attached;
    [SerializeField]
    bool Base = false;
    [SerializeField]
    bool Syre = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");

        XRGrab = GetComponent<XRGrabInteractable>();
        Developer = GameObject.Find("Developer");
        Acid = GameObject.Find("AcidTub");
        Dtransform = Developer.transform.Find("Cube.001").GetComponent<SphereCollider>().transform;
        Atransform = Acid.transform.Find("Cube.001").GetComponent<SphereCollider>().transform;
        syreScript = Acid.GetComponent<Syrebasekar>();
        baseScript = Developer.GetComponent<Syrebasekar>();
        cutoutScript = this.GetComponent<PCBCutout>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (attached == true && Base == true)
        {
            this.transform.localPosition = new Vector3(Dtransform.position.x - 0.1F, Dtransform.position.y + 0.2F, Dtransform.position.z + 0.27F);
            this.transform.localRotation = new Quaternion(90, 90, 0, 0);
        }

        if (attached == true && Syre == true)
        {
            this.transform.localPosition = new Vector3(Atransform.position.x - 0.1F, Atransform.position.y + 0.2F, Atransform.position.z + 0.27F);
            this.transform.localRotation = new Quaternion(90, 90, 0, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //OnTriggerEnter???
        if (col.gameObject.CompareTag("Developer") && attached != true)
        {
            Debug.Log("Collided with developer");
            attached = true;
            baseScript.isAttached = true;
            syreScript.isAttached = false;
            baseScript.CheckStatus();
            Base = true;
            Syre = false;

            _gameManager.GetComponent<GameManager>().Invoke("StartTimerDeveloper",0);
        }

        if (col.gameObject.CompareTag("Acid") && attached != true)
        {
            Debug.Log("Collided with acid");
            attached = true;
            syreScript.isAttached = true;
            baseScript.isAttached = false;
            syreScript.CheckStatus();
            Base = false;
            Syre = true;

            _gameManager.GetComponent<GameManager>().Invoke("StartTimerSyrekar",0);

        }
    }

   public void Grabbed()
    {
        if (attached == true)
        {
            attached = false;
            baseScript.isAttached = false;
            syreScript.isAttached = false;
            Syre = false;
            Base = false;
           
            Debug.Log("Grabbed and free");
            GameObject.Find("GameManager").GetComponent<GameManager>().StopTimer();

        }
        else
        {
            Debug.Log("Grabbed but not free");
        }
    }
}