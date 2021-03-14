using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject blockSpawnPoint;
    [SerializeField] private Transform blockSpwanPointOgPos;
    [SerializeField] private bool jump = false;
    [SerializeField] private float raiseBy = 1.5f;
    [SerializeField] private GameObject coffinMesh;
    [SerializeField] private ChangeCamera changeCamera;
    public bool stopMoving = false;
    public int numOfBlocks;
    private int numOfBlocksForUpdate;
    [SerializeField]private bool shouldChangeCamera = false;
   
    private void Start()
    {
       blockSpwanPointOgPos = blockSpawnPoint.transform;
    }
    void Update()
    {
        PlayerMovment();
        if (numOfBlocks >= 10)
        {
            if (!shouldChangeCamera)
            {
                print("More Than 10");
                CameraLogic();
                shouldChangeCamera = true;
            }
        }
        if (numOfBlocks < 10)
        {
            if (shouldChangeCamera)
            {
                print("Less Than 10");
                CameraLogic();
                shouldChangeCamera = false;
            }
        }

    }

    private void PlayerMovment()
    {
        if (!stopMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (jump)
            {
                transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            }
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
        Instantiate(block, blockSpawnPoint.transform.position, coffinMesh.transform.rotation, blockSpawnPoint.transform.parent);
        blockSpawnPoint.transform.position = new Vector3(blockSpawnPoint.transform.position.x,
                blockSpawnPoint.transform.position.y - 0.5f, blockSpawnPoint.transform.position.z);
        numOfBlocks++;
     
    }
    public void SpawnPointControll()
    {
        blockSpawnPoint.transform.position = new Vector3(blockSpawnPoint.transform.position.x,
                blockSpawnPoint.transform.position.y + 0.5f, blockSpawnPoint.transform.position.z);
        //numOfBlocks--;
    }
   
    private void CameraLogic()
    {
        changeCamera.SwitchCamera();
    }
}
