using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private int numOfStacks = 0;
    [SerializeField] private int playerHight = 0;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private Transform blockSpawnPoint;
    
    

    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        AddToStack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stackable"))
        {
            numOfStacks++;
            Destroy(other.gameObject);
        }

        if (other.GetComponent<Detacher>())
        {
            int hight = other.GetComponent<Detacher>().obstacleHight;
            
        }
    }

    private void AddToStack()
    {
        if(playerHight < numOfStacks)
        {
            playerMesh.transform.position = new Vector3(playerMesh.transform.position.x, playerMesh.transform.position.y + 0.25f, playerMesh.transform.position.z);
            Instantiate(block, blockSpawnPoint.position, transform.rotation , blockSpawnPoint.parent);
            playerHight++;
        }
    }

   
}
