using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    private PlayerCoffinScript playerScript;
    public float jumpForce = 100f;
    private Rigidbody rb;
    
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerCoffinScript>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Bob();
    }
    private void Bob()
    {
        if (playerScript.timeToBob)
        {
            rb.AddForce(Vector3.up * jumpForce);
            playerScript.timeToBob = false;
        }
    }


}
