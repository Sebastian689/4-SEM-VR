using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBPaper : MonoBehaviour
{
    public GameObject PcbPaperPrint;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Printer")) {
            StartCoroutine("PrintPCB");
        }
    }

    IEnumerator PrintPCB() {
        yield return new WaitForSeconds(2);
        Instantiate(PcbPaperPrint,new Vector3(-0.652f,0.912f,-3.689f),Quaternion.identity);
        this.gameObject.SetActive(false);
    }

}
