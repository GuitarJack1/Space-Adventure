using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniverseManager : MonoBehaviour
{
    [SerializeField]
    private PlanetUIManager uiManager;
    [SerializeField]
    private TMP_Text speedText;
    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private SimCameraMovement cameraMovement;

    [SerializeField]
    private GameObject planetPrefab;
    public ClickablePlanet[] planets;

    [SerializeField]
    private float gravitationalConstant;

    [SerializeField]
    private OrbitDebugDisplay orbitDebugDisplay;
    [SerializeField]
    PassingPlanetData planetDataToPass;

    private PlayerControls controls;
    //[SerializeField]
    //private float timeStep;

    private float speed;

    private bool simRunning;

    // Start is called before the first frame update
    void Awake()
    {
        simRunning = uiManager.simRunning;
        speed = speedSlider.value;
        speedText.text = "" + speed;

        planets = new ClickablePlanet[0];

        orbitDebugDisplay.speed = speed;
        orbitDebugDisplay.gravitationalConstant = gravitationalConstant;

        //Setup input system
        controls = new PlayerControls();
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Disable();
        }
        else
        {
            controls.Planet_Creation.Enable();
        }
    }

    void FixedUpdate()
    {

        if (simRunning)
        {
            Vector2 camMovementInput = controls.Planet_Creation.Sim_Movement.ReadValue<Vector2>();
            cameraMovement.MoveCamera(new Vector3(camMovementInput.x, 0, camMovementInput.y));

            foreach (ClickablePlanet planet in planets)
            {
                planet.UpdateVelocity(planets, Time.fixedDeltaTime * speed, gravitationalConstant);
            }

            foreach (ClickablePlanet planet in planets)
            {
                planet.UpdatePos(Time.fixedDeltaTime * speed);
            }
        }
        else
        {
            foreach (ClickablePlanet planet in planets)
            {
                planet.SetStartAttributes();
            }

            cameraMovement.ResetCamera();
        }
    }

    // Update is called once per frame
    void Update()
    {
        simRunning = uiManager.simRunning;
        orbitDebugDisplay.simRunning = simRunning;

        if (!simRunning)
            uiManager.UpdateCenterPlanetDropdown(planets);
    }

    public void UpdateSpeed()
    {
        speed = speedSlider.value;
        speedText.text = "" + speed;
    }

    public void AddPlanet()
    {
        foreach (ClickablePlanet planet in planets)
        {
            if (planet.startXPos == 0 && planet.startZPos == 0)
            {
                return;
            }
        }
        GameObject newPlanet = Instantiate(planetPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ClickablePlanet[] newArray = new ClickablePlanet[planets.Length + 1];

        for (int i = 0; i < planets.Length; i++)
        {
            newArray[i] = planets[i];
        }

        newPlanet.GetComponent<ClickablePlanet>().planetUIManager = uiManager;
        newArray[newArray.Length - 1] = newPlanet.GetComponent<ClickablePlanet>();

        planets = newArray;
    }

    public void SetCenterPlanet(Int32 choice)
    {
        if (orbitDebugDisplay)
        {
            if (choice == 0)
            {
                orbitDebugDisplay.relativeToBody = false;
            }
            else
            {
                orbitDebugDisplay.centralBody = planets[choice - 1];
                orbitDebugDisplay.relativeToBody = true;
            }
        }
    }

    public void GoExplore()
    {
        planetDataToPass.AddClickablePlanets(planets);
        planetDataToPass.gravitationalConstant = gravitationalConstant;
        controls.Planet_Creation.Disable();

        SceneManager.LoadScene("Space Scene");
    }
}
