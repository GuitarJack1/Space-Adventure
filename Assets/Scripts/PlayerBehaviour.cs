using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject connectedPlanet;

    private Rigidbody rb;
    private PlayerControls controls;

    private bool onGround = true;

    [SerializeField]
    private float gravityForce;
    [SerializeField]
    private float jumpStrength;
    [SerializeField]
    private float speedStrength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        controls = new PlayerControls();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
