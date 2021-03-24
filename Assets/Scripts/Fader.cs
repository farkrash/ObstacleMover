using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private Material lowAlphaMat;
    [SerializeField] private float alphaReduceSpeed = 2f;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.GetComponent<Renderer>() != null)
        {
            
            var renderer = other.GetComponent<Renderer>();
            Material[] materials = renderer.materials;
            foreach (var material in materials)
            {
                Color color = material.color;
                color.a -= alphaReduceSpeed * Time.deltaTime;
                material.color = color;
            }
        }
    }

    
}
