using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClickablePlanet : MonoBehaviour
{
    //Planet Info
    public string planetName = "";
    public float mass = 0;
    public float size = 0;

    public Color color = Color.green;
    public float emissionIntensity;

    public float startXPos = 0;
    public float startZPos = 0;

    public float startXVel = 0;
    public float startZVel = 0;



    private PlayerControls controls;

    private Camera cam;

    private Ray ray;
    private RaycastHit rayHit;
    private Renderer rend;

    [SerializeField]
    private PlanetUIManager planetUIManager;

    private Vector3 currVel;



    // Start is called before the first frame update
    void Start()
    {
        //Setup input system
        controls = new PlayerControls();

        cam = Camera.main;

        rend = GetComponent<Renderer>();

        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Disable();
        }
        else
        {
            controls.Planet_Creation.Enable();
            controls.Planet_Creation.Select.performed += CheckIfSelected;
        }

        SetStartAttributes();
    }

    public void SetStartAttributes()
    {
        transform.position = new Vector3(startXPos, 0, startZPos);

        currVel.x = startXVel;
        currVel.z = startZVel;

        transform.localScale = new Vector3(size, size, size);

        rend.material.color = color;
        rend.material.SetColor("_EmissionColor", color * emissionIntensity);
        rend.material.EnableKeyword("_EMISSION");
    }
    void CheckIfSelected(InputAction.CallbackContext context)
    {
        ray = cam.ScreenPointToRay(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));

        if (Physics.Raycast(ray, out rayHit, 100000f))
        {
            if (rayHit.transform == transform)
            {
                PlanetClicked();
            }
        }
    }

    public void UpdateVelocity(ClickablePlanet[] planets, float timeStep, float gravitationalConstant)
    {
        foreach (ClickablePlanet planet in planets)
        {
            if (planet != this)
            {
                float distanceSqrd = (planet.transform.position - transform.position).sqrMagnitude;
                Vector3 forceDir = (planet.transform.position - transform.position).normalized;
                Vector3 acceleration = (forceDir * planet.mass * gravitationalConstant) / distanceSqrd;

                currVel += acceleration * timeStep;
            }
        }
    }

    public void UpdatePos(float timeStep)
    {
        transform.position += currVel * timeStep;
    }

    void PlanetClicked()
    {
        planetUIManager.SetCurrentPlanet(gameObject);
    }
}
