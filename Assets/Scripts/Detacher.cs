using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detacher : MonoBehaviour
{

    private PlayerCoffinScript playerScript;
    [SerializeField] private GameObject groundCover;
    private float groundSpeed = 0.01f;
    private float moveBy = 3.2f;
    private Vector3 destination;
    private bool shouldMoveCover = false;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerCoffinScript>();
    }
    private void Start()
    {
        if (groundCover != null)
        { 
            destination = new Vector3(groundCover.transform.position.x - moveBy, groundCover.transform.position.y, groundCover.transform.position.z);
        }
    }
    private void Update()
    {
        MoveCover();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            other.transform.parent = transform.parent;
            playerScript.SpawnPointControll();
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            shouldMoveCover = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.stopMoving = true;
        }
    }

    private void MoveCover()
    {
        if(groundCover != null && shouldMoveCover)
        {
            groundCover.transform.position = Vector3.Lerp(groundCover.transform.position, destination, groundSpeed);
        }

    }
}
