using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUniverseController : MonoBehaviour
{
    [SerializeField]
    private GameObject planetPrefab;
    [SerializeField]
    private GameObject sunPrefab;
    [SerializeField]
    private GameObject planetMarkerPrefab;

    [SerializeField]
    private Transform spaceshipT;

    [SerializeField]
    private ColorSettings[] colorSettingsChoices;

    public void AddPlanet(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel, bool sun)
    {
        GameObject newPlanet = Instantiate(sun ? sunPrefab : planetPrefab);

        if (sun)
        {
            ExplorationPlanet explorationPlanetScript = newPlanet.GetComponent<ExplorationPlanet>();
            explorationPlanetScript.ChangeValues(planetName, mass, size, color, emissionIntensity, startXPos, startZPos, startXVel, startZVel, sun);
        }
        else
        {
            GameProceduralPlanet gameProceduralPlanet = newPlanet.GetComponent<GameProceduralPlanet>();
            gameProceduralPlanet.colorSettings = colorSettingsChoices[Random.Range(0, colorSettingsChoices.Length)];
            gameProceduralPlanet.GeneratePlanet();

            newPlanet.transform.localScale = new Vector3(size, size, size);
        }

        newPlanet.transform.position = new Vector3(startXPos, 0, startZPos);
        newPlanet.transform.rotation = Random.rotation;


        GameObject marker = Instantiate(planetMarkerPrefab);

        PlanetMarkerBehaviour planetMarkerBehaviour = marker.GetComponent<PlanetMarkerBehaviour>();
        planetMarkerBehaviour.attatchedPlanet = newPlanet;
        planetMarkerBehaviour.spaceshipT = spaceshipT;
    }
}
