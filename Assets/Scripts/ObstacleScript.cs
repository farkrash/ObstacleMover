using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float moveBy = 10f;
    [SerializeField] private float verticalMoveBy = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool useThis = false;
    [SerializeField] private bool moveNow = false;
    private Vector3 destination;
    [SerializeField] bool doIMoveVertically = false;

    private void Update()
    {
        ObstacleDir();
        MoveObstacle();
    }
    private void OnTriggerEnter(Collider other)
    {
        useThis = true;
    }

    private void OnTriggerExit(Collider other)
    {
        useThis = false;
    }

    private void ObstacleDir()
    {
 
        if (useThis)
        {
            if (!doIMoveVertically)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    destination = new Vector3(transform.position.x - moveBy, transform.position.y, transform.position.z);
                    moveNow = true;
                    
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    destination = new Vector3(transform.position.x + moveBy, transform.position.y, transform.position.z);
                    moveNow = true;
                    
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    destination = new Vector3(transform.position.x, transform.position.y - verticalMoveBy, transform.position.z);
                    moveNow = true;
                    
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    destination = new Vector3(transform.position.x, transform.position.y + verticalMoveBy, transform.position.z);
                    moveNow = true;
                    
                }
            }
        }
    }

    private void MoveObstacle()
    {
        if (moveNow)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed);
        }
    }
}
