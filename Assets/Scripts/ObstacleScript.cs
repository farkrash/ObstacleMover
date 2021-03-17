using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Header("Horizontal Config")]
    [SerializeField] private float horizontalMoveBy = 2f;
    
    [Header("Vertical Config")]
    [SerializeField] private float verticalMoveBy = 1f;
    [SerializeField] bool doIMoveVertically = false;
    
    [Header("Speed")]
    [SerializeField] private float speed = 0.2f;
    
    public bool useThis = false;
    private bool moveNow = false;
    private Vector3 destination;
    

    private void Update()
    {
        ObstacleDir();
        MoveObstacle();
    }
    
    private void ObstacleDir()
    {
 
        if (useThis)
        {
            if (!doIMoveVertically)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    destination = new Vector3(transform.position.x - horizontalMoveBy, transform.position.y, transform.position.z);
                    moveNow = true;
                    
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    destination = new Vector3(transform.position.x + horizontalMoveBy, transform.position.y, transform.position.z);
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
