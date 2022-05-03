using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Equip : MonoBehaviour
{
    
    GameObject _gameManager;
    
    string _name;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        
        _name = this.gameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        _gameManager.GetComponent<GameManager>().Invoke(_name,0);
        
        Destroy(gameObject);
    }
}
