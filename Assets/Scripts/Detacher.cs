using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detacher : MonoBehaviour
{

    private PlayerCoffinScript playerScript;
    [SerializeField] private GameObject groundCover;
    private float groundSpeed = 0.000001f;
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
            MoveCover();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.stopMoving = true;
        }
    }

    private void MoveCover()
    {
        if(groundCover != null)
        {
            groundCover.transform.position = new Vector3(Mathf.Lerp(transform.position.x, groundCover.transform.position.x, Time.deltaTime * groundSpeed),
                groundCover.transform.position.y, groundCover.transform.position.z);
        }

    }
}
