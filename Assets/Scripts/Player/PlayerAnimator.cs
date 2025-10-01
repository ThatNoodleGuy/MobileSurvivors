using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Moving = Animator.StringToHash("Move"); // your existing bool, optional

    private Animator animator;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private Vector2 lastDir;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 dir = playerController.GetPlayerMovementDirection();
        float speed = dir.sqrMagnitude;

        if (speed > 0.0001f)
        {
            lastDir = dir.normalized;
            animator.SetBool(Moving, true);
            // // If you only have a RIGHT clip, reuse it for LEFT by flipping:
            // if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            // {
            //     spriteRenderer.flipX = dir.x < 0f;
            // }
        }
        else
        {
            animator.SetBool(Moving, false);
        }

        // Drive the Blend Tree (use lastDir when idle so Idle faces last direction)
        Vector2 blend = (speed > 0.0001f) ? dir.normalized : lastDir;
        animator.SetFloat(MoveX, blend.x);
        animator.SetFloat(MoveY, blend.y);
        animator.SetFloat(Speed, Mathf.Sqrt(speed));
    }
}