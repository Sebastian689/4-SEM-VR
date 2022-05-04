using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBPaper : MonoBehaviour
{
    public GameObject PcbPaperPrint;
    // Start is called before the first frame update
    void Start()
    {   
        PcbPaperPrint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Print")) {
            this.gameObject.SetActive(false);
            StartCoroutine("PrintPCB");
        }
    }

    IEnumerator PrintPCB() {
        yield return new WaitForSeconds(2);
        PcbPaperPrint.SetActive(true);
    }

}
