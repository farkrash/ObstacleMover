using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    private PlayerCoffinScript playerScript;
    [SerializeField] private float jumpForce = 1f;
    private Rigidbody rb;
    public bool forceNeeded = false;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerCoffinScript>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Bob();
        //IncreasForce();
    }
    private void Bob()
    {
        if (playerScript.timeToBob)
        {
            //transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            rb.AddForce(Vector3.up * jumpForce);
            playerScript.timeToBob = false;
        }
    }

    private void IncreasForce()
    {
        if(playerScript.numOfStacks >= 1 && forceNeeded)
        {
            jumpForce = jumpForce * playerScript.numOfStacks;
            forceNeeded = false;
        }
    }
}
