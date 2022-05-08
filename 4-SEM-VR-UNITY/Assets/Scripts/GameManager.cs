using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    GameObject _text;
    public TextMeshProUGUI _setText;

    public bool labcoatEquipped;
    public bool glassesEquipped;
    public bool glovesEquipped;
    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.FindGameObjectWithTag("Text");
        _setText = _text.GetComponent<TextMeshProUGUI>();
        _text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

        StartCoroutine("StopText");
    }

    IEnumerator StopText() {
        yield return new WaitForSeconds(3);
        _text.SetActive(false);
    }
}
