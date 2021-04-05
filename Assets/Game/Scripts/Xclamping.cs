using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xclamping : MonoBehaviour
{
    private Quaternion myRotatin;
    [SerializeField] private float maxRot = 20f;

    private void Start()
    {
        myRotatin = transform.localRotation;
    }

    private void Update()
    {
        myRotatin.x = Mathf.Clamp(myRotatin.x, -maxRot, maxRot);
        print("MyRotatin" + myRotatin.x);
        print("localRotation" + transform.localRotation.x);
    }
}
