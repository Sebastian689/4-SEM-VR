using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVBottom : MonoBehaviour
{
    GameObject _gameManager;

    bool _closed = true;

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

        if (_topCurrent != _topOrigin) {
            _closed = false;
            
            _gameManager.GetComponent<GameManager>().Invoke("StopTimer",0);
        }
        else {
            _closed = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("PCBCutout") && _closed == true) {
            _gameManager.GetComponent<GameManager>().Invoke("StartTimer", 0);
        }
    }

    public void OpenPrinter() {
        if (_closed) {
            GameObject.FindGameObjectWithTag("UVTop").transform.position = new Vector3(0.0599999987f,-0.0949999988f,0.179000005f);
            GameObject.FindGameObjectWithTag("UVTop").transform.Rotate(1.00228894f,48.7940216f,357.41156f,Space.Self);

            _closed = false;
        }
        else {
            GameObject.FindGameObjectWithTag("UVTop").transform.position = _topOrigin.position;
            GameObject.FindGameObjectWithTag("UVTop").transform.rotation = _topOrigin.rotation;
            _closed = true;
        }
    }
}