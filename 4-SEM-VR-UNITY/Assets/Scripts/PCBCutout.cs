using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBCutout : MonoBehaviour
{
    GameObject gameManager;

    MeshRenderer _m;

    public Material material;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _m = this.GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("PCBPaperPrint")) {
            _m.material = material;
            
            gameManager.GetComponent<GameManager>().Invoke("ApplyPattern",0);
        }
    }
}
