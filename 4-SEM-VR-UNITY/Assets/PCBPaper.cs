using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBPaper : MonoBehaviour
{
    public GameObject PcbPaperPrint;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Printer")) {
            this.gameObject.SetActive(false);
            StartCoroutine("PrintPCB");
        }
    }

    IEnumerator PrintPCB() {
        yield return new WaitForSeconds(2);
        Instantiate(PcbPaperPrint,new Vector3(-0.652f,0.912f,-3.689f),Quaternion.identity);
    }

}
