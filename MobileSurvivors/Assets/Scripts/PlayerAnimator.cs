using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static string WALK_ANIMATOR_HASH = "Move";

    private Animator animator;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 movement = playerController.GetPlayerMovementDirection();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool(WALK_ANIMATOR_HASH, true);

            SpriteDirectonChecker();
        }
        else
        {
            animator.SetBool(WALK_ANIMATOR_HASH, false);
        }
    }

    private void SpriteDirectonChecker()
    {
        if (playerController.GetLastPlayerMovementDirection().x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerController.GetLastPlayerMovementDirection().x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}