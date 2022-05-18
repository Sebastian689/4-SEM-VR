using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syrebasekar : MonoBehaviour
{

    private Transform originalPos;
    public GameObject cube;
    public static bool isAttached = false;

    void Start() {
        cube = this.transform.Find("Cube.001").gameObject;
        originalPos = cube.transform;
        
    }

    private void Update()
    {
        //if(isAttached == true && cube.transform.position == originalPos.position)
        //{

        //    isAttached = false;
        //} else
        //{
        //    Debug.LogError("isAttached er: " + isAttached + ". OriginalPos: " + originalPos.position + ". Cube pos: " + cube.transform.position + ".");
        //}
    }

    public void CheckStatus()
    {
        if (isAttached == true && cube.transform.position == originalPos.position)
        {

            isAttached = false;
        }
        else
        {
            Debug.LogError("isAttached er: " + isAttached + ". OriginalPos: " + originalPos.position + ". Cube pos: " + cube.transform.position + ".");
        }
    }
}
