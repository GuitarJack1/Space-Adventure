using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetUIManager : MonoBehaviour
{
    private GameObject planet;
    private ClickablePlanet planetScript;

    //[SerializeField]
    //private GameObject planetPrefab;
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
    private GameObject planetInfoUI;

    // Start is called before the first frame update
    void Start()
    {
        planet = null;
        planetScript = null;
    }

    void Update(){
        planetInfoUI.SetActive(planet == null ? false : true);
    }

    public void SetCurrentPlanet(GameObject newPlanet){
        planet = newPlanet;
        planetScript = planet.GetComponent<ClickablePlanet>();

        UpdateUI();
    }

    public void UpdateUI(){
        nameInput.text = planetScript.planetName;
        sizeInput.text = "" + planetScript.size;
        massInput.text = "" + planetScript.mass;

        xPosInput.text = "" + planetScript.startXPos;
        zPosInput.text = "" + planetScript.startZPos;

        xVelInput.text = "" + planetScript.startXVel;
        zVelInput.text = "" + planetScript.startZVel;
    }
    public void UpdatePlanet(){
        planetScript.planetName = nameInput.text;
        planetScript.size = float.Parse(sizeInput.text);
        planetScript.mass = float.Parse(massInput.text);

        planetScript.startXPos = float.Parse(xPosInput.text);
        planetScript.startZPos = float.Parse(zPosInput.text);

        planetScript.startXVel = float.Parse(xVelInput.text);
        planetScript.startZVel = float.Parse(zVelInput.text);

        planetScript.SetActualAttributes();
    }

    public void GoExplore(){
        SceneManager.LoadScene("Space Scene");
    }
}
