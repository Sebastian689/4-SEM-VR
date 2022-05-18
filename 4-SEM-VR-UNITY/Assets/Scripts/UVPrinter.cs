using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVPrinter : MonoBehaviour
{
    public bool _closed = true;

    public Vector3 _topOrigin;

    public Vector3 _topCurrent;

    GameObject _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _topOrigin = this.gameObject.transform.GetChild(0).transform.position;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        _topCurrent = this.gameObject.transform.GetChild(0).transform.position;

        if (_topCurrent != _topOrigin) {
            _closed = false;
            
            _gameManager.GetComponent<GameManager>().Invoke("StopTimer",0);
        }
        else {
            _closed = true;
        }
    }

    
}
