using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassingPlanetData : MonoBehaviour
{
    public class Planet
    {
        public string planetName;
        public float mass;
        public float size;

        public Color color;
        public float emissionIntensity;

        public float startXPos;
        public float startZPos;

        public float startXVel;
        public float startZVel;

        public bool sun;

        public Planet(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel, bool sun)
        {
            this.planetName = planetName;
            this.mass = mass;
            this.size = size;
            this.color = color;
            this.emissionIntensity = emissionIntensity;
            this.startXPos = startXPos;
            this.startZPos = startZPos;
            this.startXVel = startXVel;
            this.startZVel = startZVel;
            this.sun = sun;
        }
    }

    public Planet[] planets;
    public float gravitationalConstant;

    public void AddClickablePlanets(ClickablePlanet[] newPlanets)
    {
        planets = new Planet[newPlanets.Length];
        for (int i = 0; i < newPlanets.Length; i++)
        {
            ClickablePlanet cPlanet = newPlanets[i];
            planets[i] = new Planet(cPlanet.planetName, cPlanet.mass, cPlanet.size, cPlanet.color, cPlanet.emissionIntensity, cPlanet.startXPos, cPlanet.startZPos, cPlanet.startXVel, cPlanet.startZVel, cPlanet.sun);

        }
    }

    double distanceFromZero(Planet planet)
    {
        return Math.Sqrt(Math.Pow(planet.startXPos, 2.0) + Math.Pow(planet.startZPos, 2.0));
    }

    void OnLevelWasLoaded(int index)
    {
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            GameObject universeManagerObject = GameObject.FindGameObjectWithTag("Universe Controller");

            if (universeManagerObject != null)
            {
                SpaceUniverseController universeManager = universeManagerObject.GetComponent<SpaceUniverseController>();

                foreach (Planet planet in planets)
                {
                    if (distanceFromZero(planet) < planet.size / 2.0 + 10.0)
                    {
                        GameObject spaceShip = GameObject.FindGameObjectWithTag("Spaceship");
                        spaceShip.transform.position = new Vector3(0, 0, -planet.size / 2f + 10f);
                        Debug.Log("Hello");
                    }
                    universeManager.AddPlanet(planet.planetName, planet.mass, planet.size, planet.color, planet.emissionIntensity, planet.startXPos, planet.startZPos, planet.startXVel, planet.startZVel, planet.sun);
                }
            }
        }
    }
}
