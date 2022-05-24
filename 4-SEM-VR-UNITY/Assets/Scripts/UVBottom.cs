using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVBottom : MonoBehaviour
{
    GameObject _gameManager;
    
    public bool _closed = true;

    Transform _topOrigin;

    Transform _topCurrent;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _topOrigin = GameObject.FindGameObjectWithTag("UVTop").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _topCurrent = GameObject.FindGameObjectWithTag("UVTop").transform;

        if (!_closed) {
            _gameManager.GetComponent<GameManager>().Invoke("StopTimer",0);
        }
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("PCBCutout") && _closed) {
            _gameManager.GetComponent<GameManager>().Invoke("StartTimerPrinter", 0);
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("PCBCutout") && !_closed)
        {
            other.gameObject.transform.localPosition = new Vector3(-0.703000009f, 1.68200004f, -4.43900013f);
            other.gameObject.transform.rotation = Quaternion.Euler(270.019775f,0f,0f);
        }
    }

    public void OpenPrinter() {
        if (_closed) {
            _closed = false;
            GameObject.FindGameObjectWithTag("UVTop").transform.localPosition = new Vector3(0.0599999987f,-0.0949999988f,0.179000005f);
            //GameObject.FindGameObjectWithTag("UVTop").transform.Rotate(1.00228894f,48.7940216f,357.41156f,Space.Self);
            GameObject.FindGameObjectWithTag("UVTop").transform.localRotation = Quaternion.Euler(1.00228894f,48.7940216f,357.41156f);
        }
        else {
            Debug.Log("Cringe");
            GameObject.FindGameObjectWithTag("UVTop").transform.localPosition = new Vector3(0.0160803795f,-0.107000001f,0.00400000019f);
            GameObject.FindGameObjectWithTag("UVTop").transform.localRotation = Quaternion.Euler(0,0,0);
            _closed = true;
        }
    }
}
