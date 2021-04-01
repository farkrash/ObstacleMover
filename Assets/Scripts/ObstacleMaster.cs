using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaster : MonoBehaviour
{
  [Header("Rotation Config")]
    [SerializeField] private bool doIRotate = false;
    [SerializeField] private bool doIRotateLeft = false;
    [SerializeField] private float rotateSpeed = 15f;
    
    [Header("Horizontal Movement Config")]
    [SerializeField] private bool doIMoveHorizontally = false;
    [SerializeField] private bool doIMoveLeft;
    [SerializeField] private float horizDistance = 5f;
    [SerializeField] private float horizMoveSpeed = 20f;
    
    [Header("Vertical Movement Config")]
    [SerializeField] private bool doIMoveVertically = false;
    [SerializeField] private float verticalDistance = 5f;
    [SerializeField] private float verticalMoveSpeed = 20f;
    
    [Header("Wait Time To Start Movement")]
    [SerializeField] private float waitTimeToStart;
    
    
    // Internal Bools & Floats
    private float posXog;
    private float posYog;
    private bool directionRight = true;
    private bool directionLeft;
    private bool directionUp = true;
    private bool waitTimeOver;
    private float timePassed;
    
    private void Start()
    {
        posXog = transform.position.x;
        posYog = transform.position.y;
    }
    private void Update()
    {
        
        CalculateTimePassed();
        
        if (waitTimeOver)
        {
            if (doIRotate)
            {
                Rotate();
            }

            if (doIMoveHorizontally)
            {
                MoveHorizontally();
            }

            if (doIMoveVertically)
            {
                MoveVertically();
            }
        }
       
    }

    private void Rotate()
    {
        if (!doIRotateLeft)
        {
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(Vector3.up * (-rotateSpeed * Time.deltaTime));
        }
    }

    private void MoveHorizontally()
    {
        if (!doIMoveLeft)
        {
            if (directionRight)
            {
                transform.Translate(Vector2.right * (horizMoveSpeed * Time.deltaTime));
            }
            else
            {
                transform.Translate(-Vector2.right * (horizMoveSpeed * Time.deltaTime));
            }

            if(transform.position.x >= posXog + horizDistance)
            {
                directionRight = false;
            }
            if(transform.position.x <= posXog)
            {
                directionRight = true; 
            }
        }
        else
        {
            if (directionLeft)
            {
                transform.Translate(-Vector2.right * (horizMoveSpeed * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector2.right * (horizMoveSpeed * Time.deltaTime));
            }

            if(transform.position.x <= posXog - horizDistance)
            {
                directionLeft = false;
            }
            if(transform.position.x >= posXog)
            {
                directionLeft = true; 
            }
        }
        
    }

    private void MoveVertically()
    {
        if (directionUp)
        {
            transform.Translate(Vector2.up * (verticalMoveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(-Vector2.up * (verticalMoveSpeed * Time.deltaTime));
        }

        if (transform.position.y >= posYog + verticalDistance)
        {
            directionUp = false;
        }
        if (transform.position.y <= posYog)
        {
            directionUp = true;
        }
    }

    private void CalculateTimePassed()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= waitTimeToStart)
        {
            waitTimeOver = true;
        }
        else
        {
            waitTimeOver = false;
        }
    }
}
