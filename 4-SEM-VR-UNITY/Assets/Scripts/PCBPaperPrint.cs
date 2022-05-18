using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBPaperPrint : MonoBehaviour
{
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("PCBCutout")) {
            Destroy(this.gameObject);
        }
    }
}
