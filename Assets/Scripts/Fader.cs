using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private GameObject otherGameObject;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("bitchhhhh");
        if (other.GetComponent<MeshRenderer>())
        {
            otherGameObject = other.gameObject;
            
            //other.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            //var oldColor = other.GetComponent<Renderer>().material.color;
            var oldColor = new UnityEngine.Color(0, 0, 0, 0);
            other.GetComponent<Renderer>().material.color = oldColor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("bitchhhhh2");
    }
}
