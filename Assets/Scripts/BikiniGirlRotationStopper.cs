using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikiniGirlRotationStopper : MonoBehaviour
{
    private Transform selfTrans;
    private void Awake()
    {
        selfTrans.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = selfTrans.rotation;
    }
}
