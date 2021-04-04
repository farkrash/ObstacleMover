using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour
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
        if (playerScript.numOfStacks >= 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                  Mathf.Lerp(transform.position.z, player.transform.position.z, Time.deltaTime * speed));
             transform.position = new Vector3(Mathf.Lerp(transform.position.x , player.transform.position.x , Time.deltaTime * speed), transform.position.y,
               transform.position.z);
        }
    }

}
