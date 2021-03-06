using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetacherBeach : MonoBehaviour
{

    private PlayerScript playerScript;
    private bool calledSpawPointControll = false;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            other.transform.parent = transform.parent;
            if (!calledSpawPointControll)
            {
                playerScript.SpawnPointControll();
                calledSpawPointControll = true;
            }
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.stopMoving = true;
        }
    }
}
