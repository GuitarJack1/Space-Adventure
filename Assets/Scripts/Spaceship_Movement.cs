using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship_Movement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;

    //Serialize Fields, needs input on unity screen
    [SerializeField]
    private ParticleSystem pSystem;
    [SerializeField]
    private Transform spaceshipTransform;
    [SerializeField]
    private GameObject spaceshipCamera;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float boostStrength;
    [SerializeField]
    private float rollSpeed;
    [SerializeField]
    private float pitchSpeed;
    [SerializeField]
    private float maxSpeed;



    //File variables for storing info
    private bool boosting;


    void Awake()
    {
        //Get spaceship rigidbody
        rb = GetComponent<Rigidbody>();

        //Setup input system
        controls = new PlayerControls();
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.SpaceShip.Enable();
            controls.Planet_Creation.Disable();
        }
        else
        {
            controls.SpaceShip.Disable();
        }

        boosting = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
        pSystem.startSpeed = (controls.SpaceShip.Boost.IsPressed() ? 18 : 0) + (speed / maxSpeed) * 15;
    }

    //Updates on a fixed interval, better for physics
    void FixedUpdate()
    {
        Vector2 rotationInput = controls.SpaceShip.RotationPitchRoll.ReadValue<Vector2>();
        spaceshipTransform.Rotate(rotationInput.y == 0 ? 0 : (rotationInput.y > 0 ? pitchSpeed : -pitchSpeed), 0.0f, rotationInput.x == 0 ? 0 : (rotationInput.x > 0 ? -rollSpeed : rollSpeed), Space.Self);
        Physics.SyncTransforms();

        //Boost forward
        if (controls.SpaceShip.Boost.IsPressed())
        {
            rb.AddForce(spaceshipTransform.forward * boostStrength, ForceMode.Acceleration);
        }
    }

    public void ToggleWalkingOnPlanet(bool walkingNow, GameObject hitPlanet, Collision collision)
    {
        if (walkingNow)
        {
            // Move player to the point of impact
            Vector3 colliderPos = collision.contacts[0].point;
            player.transform.position = new Vector3(colliderPos.x, colliderPos.y, colliderPos.z);
            transform.position = new Vector3(colliderPos.x, colliderPos.y, colliderPos.z);

            // Get vector between player and planet
            Vector3 towardsPlanetVector = (hitPlanet.transform.position - player.transform.position).normalized;

            // Point player away from planet
            player.transform.up = -towardsPlanetVector;
            transform.up = -towardsPlanetVector;

            //Move player and spaceship a little away from the planet (And player a little right)
            player.transform.position += -towardsPlanetVector * 1 + -player.transform.forward * 15;
            transform.position += -towardsPlanetVector * 1;

            rb.isKinematic = true;

            SC_PlanetGravity playerPlanetGravity = player.GetComponent<SC_PlanetGravity>();
            playerPlanetGravity.planet = hitPlanet.transform;

            spaceshipCamera.SetActive(false);
            player.SetActive(true);

            SC_RigidbodyWalker playerRigidbodyMovement = player.GetComponent<SC_RigidbodyWalker>();
            playerRigidbodyMovement.ToggleActive(true);

            controls.SpaceShip.Disable();
        }
        else
        {
            SC_RigidbodyWalker playerBehaviour = player.GetComponent<SC_RigidbodyWalker>();
            playerBehaviour.ToggleActive(false);

            spaceshipCamera.SetActive(true);
            player.SetActive(false);
            controls.SpaceShip.Enable();

            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && rb.isKinematic)
        {
            ToggleWalkingOnPlanet(false, null, null);
        }
        else if (collision.gameObject.CompareTag("Explore Planet"))
        {
            Debug.Log(collision.gameObject.transform.parent.gameObject);
            ToggleWalkingOnPlanet(true, collision.gameObject.transform.parent.gameObject, collision);
        }
    }
}
