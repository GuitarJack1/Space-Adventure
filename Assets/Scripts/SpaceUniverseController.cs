using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUniverseController : MonoBehaviour
{
    private List<ExplorationPlanet> planets;
    [SerializeField]
    private GameObject planetPrefab;

    void Awake()
    {
        planets = new List<ExplorationPlanet>();
    }

    public void AddPlanet(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel)
    {
        GameObject newPlanet = Instantiate(planetPrefab, new Vector3(startXPos, 0, startZPos), Quaternion.identity);

        ExplorationPlanet explorationPlanetScript = newPlanet.GetComponent<ExplorationPlanet>();
        explorationPlanetScript.ChangeValues(planetName, mass, size, color, emissionIntensity, startXPos, startZPos, startXVel, startZVel);

        planets.Add(explorationPlanetScript);
    }
}
