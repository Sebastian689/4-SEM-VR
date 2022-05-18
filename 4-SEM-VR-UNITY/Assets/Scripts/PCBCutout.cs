using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBCutout : MonoBehaviour
{
    GameObject gameManager;

    MeshRenderer _m;

    public Material material;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _m = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("PCBPaperPrint")) {
            _m.material = material;
            
            gameManager.GetComponent<GameManager>().Invoke("ApplyPattern",0);
        }
    }
}
