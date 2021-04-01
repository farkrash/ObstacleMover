using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCAnimatorSpeed : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animSpeed = 1.5f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.speed = animSpeed;
    }
}
