using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detacher : MonoBehaviour
{
    private PlayerScript playerScript;
    public int obstacleHight;

    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            other.transform.parent = transform.parent;
        }
    }
}
