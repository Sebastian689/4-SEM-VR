using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
 
    
    public void Hover()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    public void CallGrab()
    {
        this.gameObject.GetComponent<Cut_PCB>().Grabbed();
    }


}
