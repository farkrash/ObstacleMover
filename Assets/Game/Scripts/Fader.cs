using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private float alphaReduceSpeed = 2f;
    [SerializeField] private GameObject otherGameObject;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.GetComponent<Renderer>() != null)
        {
            otherGameObject = other.gameObject;
            var renderer = other.GetComponent<Renderer>();
            Material[] materials = renderer.materials;
            foreach (var material in materials)
            {
                Color color = material.color;
                if (color.a >= 0)
                {
                    color.a -= alphaReduceSpeed * Time.deltaTime;
                    material.color = color;
                }
                
            }
        }
    }

    
}
