using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowForCameraBeach : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 15f;
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
        }
    }

}
