using System;
using UnityEngine;
using UnityEngine.InputSystem;

//Ref: https://pastecode.io/s/x9v7iq1p

public class Player : MonoBehaviour
{
    // Camera rotation
    public float mouseSensitivity = .5f;
    public float verticalRotation = 0f;

    private Transform cameraTransform;

    // Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float ascendMultiplier = 2f;
    public bool isGrounded = true;
    public LayerMask groundLayer;

    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerH;
    private float raycastDist;

    //Audio
    public AudioSource footsteps;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        // Set raycast distance
        CapsuleCollider capsule = GetComponent<CapsuleCollider>();

        if (capsule != null)
        {
            playerH = capsule.height * transform.localScale.y;
            raycastDist = (playerH / 2f) + 0.2f;
        }

        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get keyboard input
        if (Keyboard.current != null)
        {
            moveHorizontal = 0f;
            moveForward = 0f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moveHorizontal = -1f;
            }


            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moveHorizontal = 1f;
            }

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                moveForward = 1f;
            }

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                moveForward = -1f;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
            {
                Jump();
            }


            //footsteps
            if (moveHorizontal != 0f || moveForward != 0f)
            {
                if (!footsteps.isPlaying)
                {
                    footsteps.Play();
                }
            }
            else
            {
                footsteps.Stop();
            }
        }

        RotateCam();

        // Ground check delay
        if (groundCheckTimer > 0f)
        {
            groundCheckTimer -= Time.deltaTime;
        }
        else if (!isGrounded)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

            isGrounded = Physics.Raycast(
                rayOrigin,
                Vector3.down,
                raycastDist,
                groundLayer
            );
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        ApplyJump();
    }

    private void MovePlayer()
    {
        Vector3 movement =
            (transform.right * moveHorizontal +
             transform.forward * moveForward).normalized;

        Vector3 targetVelocity = movement * MoveSpeed;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;

        rb.linearVelocity = velocity;

        // Stop horizontal movement when no input is pressed
        if (isGrounded && moveHorizontal == 0f && moveForward == 0f)
        {
            rb.linearVelocity = new Vector3(
                0f,
                rb.linearVelocity.y,
                0f
            );
        }
    }

    private void RotateCam()
    {
        if (Mouse.current == null)
        {
            return;
        }

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float horizontalRotation = mouseDelta.x * mouseSensitivity;
        transform.Rotate(0f, horizontalRotation, 0f);

        verticalRotation -= mouseDelta.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -50f, 50f);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }



    private void Jump()
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );
    }

    private void ApplyJump()
    {
        if (rb.linearVelocity.y < 0f)
        {
            // Falling
            rb.linearVelocity +=
                Vector3.up * Physics.gravity.y *
                fallMultiplier * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0f)
        {
            // Rising
            rb.linearVelocity +=
                Vector3.up * Physics.gravity.y *
                ascendMultiplier * Time.fixedDeltaTime;
        }
    }
}
