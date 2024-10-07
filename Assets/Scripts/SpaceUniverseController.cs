using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUniverseController : MonoBehaviour
{
    private List<ExplorationPlanet> planets;
    [SerializeField]
    private GameObject planetPrefab;
    [SerializeField]
    private GameObject sunPrefab;

    void Awake()
    {
        planets = new List<ExplorationPlanet>();
    }

    public void AddPlanet(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel, bool sun)
    {
        GameObject newPlanet = Instantiate(sun ? sunPrefab : planetPrefab, new Vector3(startXPos, 0, startZPos), Quaternion.identity);

        ExplorationPlanet explorationPlanetScript = newPlanet.GetComponent<ExplorationPlanet>();
        explorationPlanetScript.ChangeValues(planetName, mass, size, color, emissionIntensity, startXPos, startZPos, startXVel, startZVel, sun);

        planets.Add(explorationPlanetScript);
    }
}
