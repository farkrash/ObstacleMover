using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using xray;

public class XrayPoint : MonoBehaviour
{   
                     Material Material;
    [SerializeField] Transform xpoint;
    void Start()
    {
        startPoint();
    }
    void Update()
    {
        xfution.setpoint(Material, xpoint);
       
    }
    public  void startPoint()
    {
        xpoint = GameObject.FindGameObjectWithTag("xpoint").transform;

        Material = GetComponent<MeshRenderer>().material;
    }
   
}
