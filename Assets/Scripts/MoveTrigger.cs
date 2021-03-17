using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private ObstacleScript obstacleScript;

    private void Awake()
    {
        obstacleScript = GetComponentInParent<ObstacleScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Holder"))
        {
            obstacleScript.useThis = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player Holder"))
        {
            obstacleScript.useThis = false;
        }
    }
}
