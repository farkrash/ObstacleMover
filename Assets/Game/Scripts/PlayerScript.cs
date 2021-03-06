using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float horizontalMoveSpeed = 5f;
    private Rigidbody rb;
    private bool atEnd = false;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Girl;
    private bool noRB = true;
    [SerializeField] private GameObject trail;
    [SerializeField] private BoxCollider playerBoxCollider;
    [SerializeField] GameObject cocktail;

    [Header("Jump Config")]
    [SerializeField] private bool jump = false;
    [SerializeField] private float jumpForce = 15f;
    private float rotationForGirl = 10f;
    
    [Header("Stacks Config")]
    [SerializeField] private GameObject stack;
    [SerializeField] private GameObject stackMesh;
    [SerializeField] private GameObject stackSpawnPoint;
    [SerializeField] private float raiseBy = 1.5f;
    [SerializeField] private float spawnPointRaiseBy;
    public int numOfStacks;
    private int numOfStacksForUpdate;
    
    [Header("Camera Config")]
    [SerializeField] private int stacksForCameraChange = 10;
    [SerializeField] private ChangeCamera changeCamera;
    private bool shouldChangeCamera = false;
    public bool stopMoving = false;
    private bool switchedCamera = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerBoxCollider.enabled = false;
    }
    void Update()
    {
        PlayerMovment();
        CameraLogic();
    }

    private void PlayerMovment()
    {
        if (!stopMoving)
        {
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

            if (jump)
            {
                transform.Translate(Vector3.up * (jumpForce * Time.deltaTime));
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            trail.SetActive(false);
            if (!atEnd)
            {
                animator.SetBool("GotHit", true);
                if (noRB)
                {
                    cocktail.SetActive(false);
                    var rigidbody = Girl.AddComponent<Rigidbody>();
                    Girl.transform.parent = null;
                    rigidbody.AddForce(Vector3.up * 350);
                    rigidbody.AddForce(Vector3.right * 200);
                    rigidbody.AddForce(Vector3.forward * 300);
                    noRB = false;
                }
            }
            else
            {
                
                animator.SetBool("atEnd", true);
                Girl.transform.Rotate( new Vector3(0, rotationForGirl, 0));
                Invoke("RotationToZero", 0.1f);
                if (noRB)
                {
                    cocktail.SetActive(false);
                    var rigidbody = Girl.AddComponent<Rigidbody>();
                    playerBoxCollider.enabled = true;
                    Girl.transform.parent = null;
                    rigidbody.AddForce(Vector3.up * 300);
                    rigidbody.AddForce(Vector3.forward * 250); // IF AT TOP SET TO 250, set to 150 if not at top
                    changeCamera.SwitchCamera();
                    noRB = false;
                    
                }
            }
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * horizontalMoveSpeed * Time.deltaTime, 0 ,0);
      
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
        if (other.gameObject.CompareTag("EndStopper"))
        {
            moveSpeed = 7.5f;
            atEnd = true;
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
                stackSpawnPoint.transform.position.y - spawnPointRaiseBy, stackSpawnPoint.transform.position.z);
        numOfStacks++;
     
    }
    public void SpawnPointControll()
    {
        stackSpawnPoint.transform.position = new Vector3(stackSpawnPoint.transform.position.x,
                stackSpawnPoint.transform.position.y + spawnPointRaiseBy, stackSpawnPoint.transform.position.z);
        print("spawnPontControll");
    }
   
    private void CameraLogic()
    {
        
        if (!atEnd)
        {
            /*
            if (numOfStacks >= stacksForCameraChange)
            {
                if (!shouldChangeCamera)
                {

                    changeCamera.SwitchCamera();
                    shouldChangeCamera = true;
                }
            }
            if (numOfStacks < stacksForCameraChange)
            {
                if (shouldChangeCamera)
                {
                    
                    changeCamera.SwitchCamera();
                    shouldChangeCamera = false;
                }
            }
            */
        }
        else
        {
            if (!switchedCamera)
            {
                changeCamera.SwitchCamera();
                switchedCamera = true;
            }
        }
         
    }
    private void RotationToZero()
    {
        rotationForGirl = 0f;
    }
}
