using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRooms : MonoBehaviour
{
    Vector3 temp = new Vector3(0,0.1f,-3f);

    public void ChangeRoom()
    {
        transform.position = temp;
    }
}
