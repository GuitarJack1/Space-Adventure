using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class SC_RigidbodyWalker : MonoBehaviour
{
    public float speedForce = 15.0f;
    public float maxSpeed = 15.0f;
    public float jumpHeight = 2.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float upDownLimit = 60.0f;
    public float groundDrag = 0;
    private PlayerControls controls;

    bool grounded = false;
    Rigidbody rb;
    Vector2 rotation = Vector2.zero;
    float maxVelocityChange = 10.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rotation.y = transform.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controls = new PlayerControls();

        gameObject.SetActive(false);
    }

    void Update()
    {
        Vector2 mouseVector = controls.Player.Mouse.ReadValue<Vector2>();

        // Player and Camera rotation
        rotation.x += -mouseVector.y * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -upDownLimit, upDownLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);

        Quaternion localRotation = Quaternion.Euler(0f, mouseVector.x * lookSpeed, 0f);
        transform.rotation = transform.rotation * localRotation;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            rb.drag = groundDrag;

            // Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
            // Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;

            Vector2 movementInputVector = controls.Player.Movement.ReadValue<Vector2>();
            Vector3 movementDirection = transform.forward * movementInputVector.y + transform.right * movementInputVector.x;

            // Vector3 velocity = transform.InverseTransformDirection(r.velocity);
            // velocity.y = 0;
            // velocity = transform.TransformDirection(velocity);
            // Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
            // velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            // velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            // velocityChange.y = 0;
            // velocityChange = transform.TransformDirection(velocityChange);

            rb.AddForce(movementDirection.normalized * speedForce);

            if (controls.Player.Jump.IsPressed() && grounded)
            {
                rb.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
                grounded = false;
            }
        }
        else
        {
            rb.drag = 0;
        }

        SpeedLimit();
    }

    void SpeedLimit()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 newVel = flatVel.normalized * speedForce;
            rb.velocity = new Vector3(newVel.x, rb.velocity.y, newVel.z);
        }

    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    public void ToggleActive(bool walkingNow)
    {
        if (walkingNow)
        {
            controls.Player.Enable();
        }
        else
        {
            controls.Player.Disable();
        }
    }
}
