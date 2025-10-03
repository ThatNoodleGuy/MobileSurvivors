using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterScriptableObject characterData;

    private PlayerControls controls;
    private Rigidbody2D rb2d;
    private Vector2 movementDirection;
    private float lastHorizontalInput;
    private float lastVerticalInput;
    private Vector2 lastMovementDirection;

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
        lastMovementDirection = Vector2.right;
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
            lastMovementDirection = new Vector2(lastHorizontalInput, 0);
        }

        if (movementDirection.y != 0)
        {
            lastVerticalInput = movementDirection.y;
            lastMovementDirection = new Vector2(0, lastVerticalInput);
        }

        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            lastMovementDirection = new Vector2(lastHorizontalInput, lastVerticalInput);
        }
    }

    public void Move()
    {
        rb2d.linearVelocity = movementDirection * characterData.MoveSpeed;
    }

    public Vector2 GetPlayerMovementDirection()
    {
        return movementDirection;
    }

    public Vector2 GetLastPlayerMovementDirection()
    {
        return lastMovementDirection;
    }
    
}