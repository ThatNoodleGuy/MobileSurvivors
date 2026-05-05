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

<<<<<<< HEAD
    [SerializeField] private float moveSpeed;

    private Transform playerTransform;
    private Animator animator;
=======
    [SerializeField] private EnemyScriptableObject enemyData;

    private Transform playerTransform;
    private Animator animator;
    private float moveSpeed;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647

    private void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
<<<<<<< HEAD
=======
        moveSpeed = enemyData.MoveSpeed;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        animator.SetFloat(MoveX, direction.x);
        animator.SetFloat(MoveY, direction.y);
        animator.SetFloat(Speed, direction.sqrMagnitude);

        
    }
}