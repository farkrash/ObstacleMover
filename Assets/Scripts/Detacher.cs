using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detacher : MonoBehaviour
{

    private PlayerCoffinScript playerScript;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerCoffinScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            other.transform.parent = transform.parent;
            playerScript.SpawnPointControll();
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.stopMoving = true;
        }
    }
}
