using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isJumping = false;
    public float speed = 5;

    // Backing field for health
    [SerializeField]
    private int health = 100;

    // Property to control access to health
    public int Health
    {
        get { return health; }
        set
        {
            // Ensure health is within a valid range
            health = Mathf.Clamp(value, 0, 100);
            Debug.Log("Player Health: " + health);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue movementValue)
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        Health -= 10;

    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}