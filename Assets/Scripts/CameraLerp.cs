using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private float speed = 15f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 
            Mathf.Lerp(transform.position.z, cameraPos.transform.position.z, Time.deltaTime * speed));
    }

}
