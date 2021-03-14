using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    private PlayerScript player;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private Transform cameraPos2;
    [SerializeField] private float speed = 15f;
    [SerializeField] private Transform cameraPos2OG;
    private bool transitionToPos2 = false;
    private bool transitionToPos1 = false;
    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>();
    }
    void Update()
    {
        ControllCamera();
        Transition();
    }

    private void ControllCamera()
    {
        

        if (player.numOfBlocks >= 10)
        {
            transform.position = new Vector3(transform.position.x, cameraPos2OG.position.y,
              Mathf.Lerp(transform.position.z, cameraPos2.transform.position.z, Time.deltaTime * speed));
        }
        if(player.numOfBlocks < 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
              Mathf.Lerp(transform.position.z, cameraPos.transform.position.z, Time.deltaTime * speed));
        }
    }

    private void Transition()
    {
        if (player.numOfBlocks >= 10)
        {
            transitionToPos1 = false;
            transitionToPos2 = true;
        }
        if (player.numOfBlocks < 10)
        {
            transitionToPos1 = true;
            transitionToPos2 = false;
        }
    }
}
