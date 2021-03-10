using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private GameObject block;
    [SerializeField] private Transform blockSpawnPoint;
    [SerializeField] private bool jump = false;
    [SerializeField] private float raiseBy = 1.5f;

    void Update()
    {
        PlayerMovment();
    }

    private void PlayerMovment()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (jump)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stackable"))
        {
            AddToStack();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Spring"))
        {
            jump = true;
            Invoke("JumpToFalse", 1f);
        }
    }

    private void JumpToFalse()
    {
        jump = false;
    }

    private void AddToStack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + raiseBy, transform.position.z);
        Instantiate(block, blockSpawnPoint.position, transform.rotation , blockSpawnPoint.parent);
    }

   
}
