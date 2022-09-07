using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public bool isRunning;
    public GameObject gameObject;
    public PlayerClass(bool isRunning)
    {
        this.isRunning = isRunning;
    }
}