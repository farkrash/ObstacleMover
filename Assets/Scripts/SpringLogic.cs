using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLogic : MonoBehaviour
{
    [SerializeField] private float force = 50;
    [SerializeField] private bool useThis = false;
    [SerializeField] private float moveBy = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool moveNow = false;
    private Vector3 destination;

    private void Update()
    {
        MoveObstacle();
        if (moveNow)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.rigidbody != null)
       {
            Rigidbody rb = collision.rigidbody;
            print(collision);
            rb.AddForce(Vector3.up * force);
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        useThis = true;
    }

    private void OnTriggerExit(Collider other)
    {
        useThis = false;
    }
    private void MoveObstacle()
    {

        if (useThis)
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
    }
}
