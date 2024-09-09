using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship_Movement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;

    //Serialize Fields, needs input on unity screen
    [SerializeField]
    private Transform spaceshipTransform;
    [SerializeField]
    private float boostStrength;
    [SerializeField]
    private float rollSpeed;
    [SerializeField]
    private float pitchSpeed;

    //File variables for storing info
    private bool boosting;
    
    
    void Awake()
    {
        //Get spaceship rigidbody
        rb = GetComponent<Rigidbody>();

        //Setup input system
        controls = new PlayerControls();
        if (SceneManager.GetActiveScene ().name == "Space Scene"){
            controls.SpaceShip.Enable();
        }else{
            controls.SpaceShip.Disable();
        }

        boosting = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        boosting = controls.SpaceShip.Boost.IsPressed();

        Vector2 rotationInput = controls.SpaceShip.RotationPitchRoll.ReadValue<Vector2>();
        spaceshipTransform.Rotate(rotationInput.y == 0 ? 0 : (rotationInput.y > 0 ? pitchSpeed : -pitchSpeed), 0.0f, rotationInput.x == 0 ? 0 : (rotationInput.x > 0 ? -rollSpeed : rollSpeed), Space.Self);
    }

    //Updates on a fixed interval, better for physics
    void FixedUpdate(){
        //Boost forward
        if (boosting){
            rb.AddForce(spaceshipTransform.forward * boostStrength, ForceMode.Acceleration);
        }
    }
}
