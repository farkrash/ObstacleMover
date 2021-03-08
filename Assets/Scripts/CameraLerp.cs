using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPos.position, speed * Time.deltaTime);
    }
}
