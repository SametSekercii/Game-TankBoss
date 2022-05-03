using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour,ISense
{
    public abstract void InitialiazeSense();
    public abstract void UpdateSense();
    

    void Start()
    {
        InitialiazeSense();
    }

    
    void Update()
    {
        UpdateSense();   
    }
}
