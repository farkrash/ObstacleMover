﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoffinScript : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] private float moveSpeed = 15f;
    private Rigidbody rb;
    [SerializeField] private GameObject playerCoffin;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animator2;
    [SerializeField] private Animator animator3;
    [SerializeField] private Animator animator4;
    private bool atEnd = false;
    private bool lunch = false;
    private GameManager gameManager;


    [Header("Jump Config")]
    [SerializeField] private bool jump = false;
    [SerializeField] private float jumpForce = 15f;

    [Header("Stacks Config")]
    [SerializeField] private GameObject stack;
    [SerializeField] private GameObject stackMesh;
    [SerializeField] private GameObject stackSpawnPoint;
    [SerializeField] private float raiseBy = 1.5f;
    [SerializeField] private float bobTime = 1f;
    [SerializeField] private GameObject coffinHolder;
    private float timeFromLastBob = 0f;
    public int numOfStacks;
    private int numOfStacksForUpdate;
    public bool timeToBob = false;
    private BobbingEffect bobbingEffect;

    [Header("Camera Config")]
    [SerializeField] private int stacksForCameraChange = 10;
    [SerializeField] private ChangeCamera changeCamera;
    private bool shouldChangeCamera = false;
    public bool stopMoving = false;





    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bobbingEffect = GetComponentInChildren<BobbingEffect>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        PlayerMovment();
        StopMovingWhenFall();
        if (!lunch)
        {
            BobLogic();
        }
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
                transform.Translate(Vector3.up * (jumpForce * Time.deltaTime));
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (atEnd)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lunch = true;
                animator.SetBool("Throw", true);
                animator2.SetBool("Throw", true);
                animator3.SetBool("Throw", true);
                animator4.SetBool("Throw", true);
            }
            if (lunch)
            {
                Invoke("ThrowCoffin", 0.5f);
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

        if (other.gameObject.CompareTag("EndStopper"))
        {
            atEnd = true;
            SwitchDance();
            bobbingEffect.jumpForce = 0f;
        }

        if (other.gameObject.CompareTag("Collectable"))
        {
            gameManager.AddToScore();
            Destroy(other.gameObject);
        }
    }

    private void JumpToFalse()
    {
        jump = false;
    }

    private void AddToStack()
    {
        //playerCoffin.transform.position = new Vector3(playerCoffin.transform.position.x, playerCoffin.transform.position.y + raiseBy, playerCoffin.transform.position.z);
        Instantiate(stack, stackSpawnPoint.transform.position, stackMesh.transform.rotation, playerCoffin.transform.parent);
        stackSpawnPoint.transform.position = new Vector3(stackSpawnPoint.transform.position.x,
                stackSpawnPoint.transform.position.y + 1f, stackSpawnPoint.transform.position.z);
        numOfStacks++;
        SwitchDance();
    }
    public void SpawnPointControll()
    {
        stackSpawnPoint.transform.position = new Vector3(stackSpawnPoint.transform.position.x,
                 stackSpawnPoint.transform.position.y - 0.5f, stackSpawnPoint.transform.position.z);

    }

    private void CameraLogic()
    {
        changeCamera.SwitchCamera();
    }

    private void BobLogic()
    {
        timeFromLastBob += Time.deltaTime;

        if (timeFromLastBob >= bobTime)
        {
            timeToBob = true;
            timeFromLastBob = 0f;
        }
    }

    private void SwitchDanceToFlase()
    {
        animator.SetBool("SwitchDance", false);
        animator2.SetBool("SwitchDance", false);
        animator3.SetBool("SwitchDance", false);
        animator4.SetBool("SwitchDance", false);
    }

    private void ThrowCoffin()
    {
        coffinHolder.transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    private void SwitchDance()
    {
        animator.SetBool("SwitchDance", true);
        animator2.SetBool("SwitchDance", true);
        animator3.SetBool("SwitchDance", true);
        animator4.SetBool("SwitchDance", true);
        Invoke("SwitchDanceToFlase", 1f);
    }

    private void StopMovingWhenFall()
    {
        if (transform.position.y <= 1f)
        {
            stopMoving = true;
        }
    }
}
