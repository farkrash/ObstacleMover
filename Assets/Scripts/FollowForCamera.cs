using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowForCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 15f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
              Mathf.Lerp(transform.position.z, player.transform.position.z, Time.deltaTime * speed));
    }

}
