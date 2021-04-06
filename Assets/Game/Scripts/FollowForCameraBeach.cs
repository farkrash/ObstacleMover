using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowForCameraBeach : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float ySpeed = 1f;
    [SerializeField] private bool lerpY;
    private PlayerScript playerScript;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }
    void Update()
    {
        if (playerScript.numOfStacks >=1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                  Mathf.Lerp(transform.position.z, player.transform.position.z, Time.deltaTime * speed));
            if (lerpY)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * ySpeed),
                    transform.position.z);
            }
            
        }
    }

}
