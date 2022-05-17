using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syrebasekar : MonoBehaviour
{

    public bool PCBattached = false;
    public Animator anim;

    void Start() {
        anim = this.gameObject.GetComponent<Animator>();
        
    }

    public void Animation () {
        anim.Play("Scene");
        Debug.Log("Playing Scene");
    }
}
