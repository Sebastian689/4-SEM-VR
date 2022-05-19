using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWater : MonoBehaviour
{
    
    public GameObject water;

    private bool isWaterOn;

    public void WaterOnOff()
    {
        if (isWaterOn)
        {
            water.SetActive(false);
            isWaterOn = false;
        }
        else
        {
            water.SetActive(true);
            isWaterOn = true;
        }
        
    }
}
