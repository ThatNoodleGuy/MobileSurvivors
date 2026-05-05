using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int Speed = Animator.StringToHash("Speed");

    [SerializeField] private float moveSpeed;

    private Transform playerTransform;
    private Animator animator;

    private void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        animator.SetFloat(MoveX, direction.x);
        animator.SetFloat(MoveY, direction.y);
        animator.SetFloat(Speed, direction.sqrMagnitude);

        
    }
}