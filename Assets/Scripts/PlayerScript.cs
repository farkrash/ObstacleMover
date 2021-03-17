using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] private float moveSpeed = 15f;
    private Rigidbody rb;
    
    [Header("Jump Config")]
    [SerializeField] private bool jump = false;
    [SerializeField] private float jumpSpeed = 15f;
    
    [Header("Stacks Config")]
    [SerializeField] private GameObject stack;
    [SerializeField] private GameObject stackMesh;
    [SerializeField] private GameObject stackSpawnPoint;
    [SerializeField] private float raiseBy = 1.5f;
    public int numOfStacks;
    private int numOfStacksForUpdate;
    
    [Header("Camera Config")]
    [SerializeField] private int stacksForCameraChange = 10;
    [SerializeField] private ChangeCamera changeCamera;
    private bool shouldChangeCamera = false;
    public bool stopMoving = false;
    
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerMovment();
        if (numOfStacks >= stacksForCameraChange)
        {
            if (!shouldChangeCamera)
            {
                print("More Than 10");
                CameraLogic();
                shouldChangeCamera = true;
            }
        }
        if (numOfStacks < stacksForCameraChange)
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
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

            if (jump)
            {
                transform.Translate(Vector3.up * (jumpSpeed * Time.deltaTime));
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
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
        Instantiate(stack, stackSpawnPoint.transform.position, stackMesh.transform.rotation, stackSpawnPoint.transform.parent);
        stackSpawnPoint.transform.position = new Vector3(stackSpawnPoint.transform.position.x,
                stackSpawnPoint.transform.position.y - 0.5f, stackSpawnPoint.transform.position.z);
        numOfStacks++;
     
    }
    public void SpawnPointControll()
    {
        stackSpawnPoint.transform.position = new Vector3(stackSpawnPoint.transform.position.x,
                stackSpawnPoint.transform.position.y + 0.5f, stackSpawnPoint.transform.position.z);
        
    }
   
    private void CameraLogic()
    {
        changeCamera.SwitchCamera();
    }
}
