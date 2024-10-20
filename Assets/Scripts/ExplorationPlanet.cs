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

    private MeshRenderer rend;

    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();

        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        if (rend && rend.material)
        {
            rend.material.color = color;
            rend.material.SetColor("_EmissionColor", color * emissionIntensity);
            rend.material.EnableKeyword("_EMISSION");
        }

        transform.position = new Vector3(startXPos, 0, startZPos);
        transform.localScale = new Vector3(size, size, size);
    }

    public void ChangeValues(string planetName, float mass, float size, Color color, float emissionIntensity, float startXPos, float startZPos, float startXVel, float startZVel, bool sun)
    {
        this.planetName = planetName;
        this.mass = mass;
        this.size = size;
        this.color = color;
        this.emissionIntensity = sun ? 1 : emissionIntensity;
        this.startXPos = startXPos;
        this.startZPos = startZPos;
        this.startXVel = startXVel;
        this.startZVel = startZVel;

        UpdateVisuals();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Spaceship"))
        {
            Spaceship_Movement spaceshipMovement = collider.GetComponent<Spaceship_Movement>();
            spaceshipMovement.ToggleWalkingOnPlanet(true, gameObject, collision);
        }
    }
}
