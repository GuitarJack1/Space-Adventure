using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMarkerBehaviour : MonoBehaviour
{
    public GameObject attatchedPlanet;
    public Transform spaceshipT;
    public float hoverHeight;


    private Image markerImage;
    private Transform thisTransform;
    private Transform thisRectTransform;
    private Transform planetTransform;

    // Start is called before the first frame update
    void Start()
    {
        markerImage = GetComponentInChildren<Image>();
        thisTransform = GetComponent<Transform>();
        thisRectTransform = GetComponent<RectTransform>();
        planetTransform = attatchedPlanet.transform;

        UpdateVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisTransform != null)
        {
            thisTransform.position = new Vector3(planetTransform.transform.position.x, spaceshipT.transform.position.y + hoverHeight, planetTransform.transform.position.z);
        }
        else
        {
            thisRectTransform.position = new Vector3(planetTransform.transform.position.x, spaceshipT.transform.position.y + hoverHeight, planetTransform.transform.position.z);
        }

        if (true) //If rotating with player
        {
            if (thisTransform != null)
            {
                thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, planetTransform.eulerAngles.y, thisTransform.eulerAngles.z);
            }
            else
            {
                thisRectTransform.eulerAngles = new Vector3(thisRectTransform.eulerAngles.x, planetTransform.eulerAngles.y, thisRectTransform.eulerAngles.z);
            }
        }
    }

    public void UpdateVisuals()
    {
        if (attatchedPlanet != null)
        {
            markerImage.color = attatchedPlanet.GetComponent<ExplorationPlanet>().color;
        }
    }
}
