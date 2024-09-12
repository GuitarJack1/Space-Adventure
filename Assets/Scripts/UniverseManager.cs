using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseManager : MonoBehaviour
{
    [SerializeField]
    private PlanetUIManager uiManager;

    [SerializeField]
    private ClickablePlanet[] planets;

    [SerializeField]
    private float gravitationalConstant;
    //[SerializeField]
    //private float timeStep;

    private bool simRunning;

    // Start is called before the first frame update
    void Start()
    {
        simRunning = uiManager.simRunning;
        //Time.fixedDeltaTime = timeStep;
    }

    void FixedUpdate()
    {
        if (simRunning)
        {
            foreach (ClickablePlanet planet in planets)
            {
                planet.UpdateVelocity(planets, Time.fixedDeltaTime, gravitationalConstant);
            }

            foreach (ClickablePlanet planet in planets)
            {
                planet.UpdatePos(Time.fixedDeltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        simRunning = uiManager.simRunning;
    }
}
