using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerControls controls;
    private Rigidbody2D rb2d;
    private Vector2 movementDirection;
    private float lastHorizontalInput;
    private float lastVerticalInput;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Movement.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Movement.Disable();
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void GetPlayerInput()
    {
        movementDirection = controls.Player.Movement.ReadValue<Vector2>();

        if (movementDirection.x != 0)
        {
            lastHorizontalInput = movementDirection.x;
        }

        if (movementDirection.y != 0)
        {
            lastVerticalInput = movementDirection.y;
        }
    }

    public void Move()
    {
        rb2d.linearVelocity = movementDirection * moveSpeed;
    }

    public Vector2 GetPlayerMovementDirection()
    {
        return movementDirection;
    }

    public Vector2 GetLastPlayerMovementDirection()
    {
        return new Vector2(lastHorizontalInput, lastVerticalInput);
    }
    
}