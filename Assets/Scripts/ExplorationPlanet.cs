using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationPlanet : MonoBehaviour
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

    public ExplorationPlanet(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel)
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
    }
}
