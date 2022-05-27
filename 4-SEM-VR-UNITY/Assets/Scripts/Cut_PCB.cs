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

    private GameObject _particles;
   
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
    // Attributes objects from game to values declared within script.
    void Start()
    {
        _particles = gameObject.transform.GetChild(0).gameObject;
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
    // Makes certain that when the PCB must attach to the developer bath, it does so.
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


    // Detects collisions between the PCB and the developer baths. Depending on which it collides with it initiates the functionality of the update function by changing boolean values. Then invokes the timer from the GamemManager.
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.CompareTag("Developer") && attached != true)
        {
            _particles.SetActive(true);
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
            _particles.SetActive(true);
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


    // When grabbed this function is called by the interactable event system. The Update function is stopped by changing boolean values,
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
            _gameManager.GetComponent<GameManager>().Invoke("StopTimer",0);

        }
        else
        {
            Debug.Log("Grabbed but not free");
        }
    }
}