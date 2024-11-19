using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetUIManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject planet;
    private ClickablePlanet planetScript;

    //[SerializeField]
    //private GameObject planetPrefab;

    //Input text
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_InputField sizeInput;
    [SerializeField]
    private TMP_InputField massInput;
    [SerializeField]
    private TMP_InputField xPosInput;
    [SerializeField]
    private TMP_InputField zPosInput;
    [SerializeField]
    private TMP_InputField xVelInput;
    [SerializeField]
    private TMP_InputField zVelInput;
    [SerializeField]
    private TMP_Dropdown centerPlanetDropdown;
    [SerializeField]
    FlexibleColorPicker flexibleColorPicker;
    [SerializeField]
    Toggle sunToggle;

    //Other needed objects
    [SerializeField]
    private TMP_Text simRunningText;

    [SerializeField]
    private GameObject planetInfoUI;

    public bool simRunning;

    // Start is called before the first frame update
    void Start()
    {
        planet = null;
        planetScript = null;

        simRunning = false;
    }

    void Update()
    {
        planetInfoUI.SetActive(planet != null && !simRunning);

        UpdatePlanetColor(flexibleColorPicker.color);
    }

    public void SetCurrentPlanet(GameObject newPlanet)
    {
        planet = newPlanet;
        planetScript = planet.GetComponent<ClickablePlanet>();

        UpdateUI();
    }

    public void UpdatePlanetColor(Color color)
    {
        if (planetScript)
        {
            planetScript.color = color;
        }
    }

    public void UpdateUI()
    {
        flexibleColorPicker.color = planetScript.color;
        nameInput.text = planetScript.planetName;
        sizeInput.text = "" + planetScript.size;
        massInput.text = "" + planetScript.mass;

        xPosInput.text = "" + planetScript.startXPos;
        zPosInput.text = "" + planetScript.startZPos;

        xVelInput.text = "" + planetScript.startXVel;
        zVelInput.text = "" + planetScript.startZVel;

        sunToggle.isOn = planetScript.sun;
    }
    public void UpdatePlanet()
    {
        planetScript.planetName = nameInput.text;
        planetScript.size = float.Parse(sizeInput.text);
        planetScript.mass = float.Parse(massInput.text);

        planetScript.startXPos = float.Parse(xPosInput.text);
        planetScript.startZPos = float.Parse(zPosInput.text);

        planetScript.startXVel = float.Parse(xVelInput.text);
        planetScript.startZVel = float.Parse(zVelInput.text);

        planetScript.sun = sunToggle.isOn;
    }

    public void ToggleSim()
    {
        simRunning = !simRunning;

        simRunningText.text = simRunning ? "Stop Sim" : "Start Sim";
    }

    public void UpdateCenterPlanetDropdown(ClickablePlanet[] planets)
    {
        List<TMP_Dropdown.OptionData> newOptionData = new()
        {
            new TMP_Dropdown.OptionData("None")
        };

        for (int i = 0; i < planets.Length; i++)
        {
            newOptionData.Add(new TMP_Dropdown.OptionData(planets[i].GetComponent<ClickablePlanet>().planetName));
        }

        centerPlanetDropdown.options = newOptionData;
    }
}
