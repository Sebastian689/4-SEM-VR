using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{   
    GameObject _text;
    public float _currentTime;
    bool _timerActive = false;

    public TextMeshProUGUI _setText;

    public GameObject UncutPCB;

    public GameObject PCBPaper;

    public GameObject Drawer;
    Vector3 _drawerPos;



    public bool labcoatEquipped;
    public bool glassesEquipped;
    public bool glovesEquipped;

    public bool patternApplied;


    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.FindGameObjectWithTag("Text");
        _setText = _text.GetComponent<TextMeshProUGUI>();
        _text.SetActive(false);

        _currentTime = 0;

        _drawerPos = Drawer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (_timerActive == true) {
            _currentTime = _currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            _text.SetActive(true);
            _setText.text = time.ToString(@"mm\:ss\:fff");

            if (_currentTime > 85) {
                StopTimer();
                _text.SetActive(true);
                _setText.text = "The PCB has been in the UV printer for too long, and is ruined.";
                _currentTime = 0;
                Restart();

            }
        }
        
    }

    void StartTimer() {
        Debug.Log("Timer started");
        _timerActive = true;
    }

    void StopTimer() {
        Debug.Log("Timer stopped");
        _timerActive = false;
        _text.SetActive(false);
    }

    void Labcoat() {

        labcoatEquipped = true;
        _text.SetActive(true);

        if (labcoatEquipped && glovesEquipped && glassesEquipped) {
            Debug.Log("All items equipped");
            _setText.SetText("All safety items equipped. The door is now open");
            GameObject.FindGameObjectWithTag("Door").SetActive(false);
        }
        else {
            _setText.SetText("Lab coat equipped!");
        }

        StopAllCoroutines();
        StartCoroutine("StopText");
    }

    void Glasses() {

        glassesEquipped = true;
        _text.SetActive(true);

        if (labcoatEquipped && glovesEquipped && glassesEquipped) {
            _setText.text = "All safety items equipped. The door is now open";
            GameObject.FindGameObjectWithTag("Door").SetActive(false);
        }
        else {
            _setText.text = "Safety glasses equipped!";
        }

        StopAllCoroutines();
        StartCoroutine("StopText");
    }

    void Gloves() {

        glovesEquipped = true;
        _text.SetActive(true);

        if (labcoatEquipped && glovesEquipped && glassesEquipped) {
            _setText.text = "All safety items equipped. The door is now open";
            GameObject.FindGameObjectWithTag("Door").SetActive(false);
        }
        else {
            _setText.text = "Safety gloves equipped!";
        }

        StopAllCoroutines();
        StartCoroutine("StopText");
    }

    void ApplyPattern() {
        patternApplied = true;
        _setText.text = "Pattern has been applied to the PCB";

        StopAllCoroutines();
        StartCoroutine("StopText");
    }

    void Restart() {
        
        Drawer.transform.position = _drawerPos;

        Instantiate(UncutPCB, new Vector3(0.243049994f,0.899500012f,-1.54264998f), Quaternion.identity);

        Instantiate(PCBPaper, new Vector3(-0.627099991f,0.333999991f,-3.51789999f), Quaternion.identity);

        StopAllCoroutines();
        StartCoroutine("StopText");
    }

    IEnumerator StopText() {
        
        yield return new WaitForSeconds(3);
        _text.SetActive(false);
    }
}
