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

    private Rigidbody rb;
    private Renderer rend;
    private Transform trans;

    [SerializeField]
    private PlanetUIManager planetUIManager;

    // Start is called before the first frame update
    void Start()
    {
        //Setup input system
        controls = new PlayerControls();

        cam = Camera.main;

        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        trans = GetComponent<Transform>();

        if (SceneManager.GetActiveScene ().name == "Space Scene"){
            controls.Planet_Creation.Disable();
        }else{
            controls.Planet_Creation.Enable();
            controls.Planet_Creation.Select.performed += CheckIfSelected;
        }

        rb.constraints = RigidbodyConstraints.FreezePosition;
        SetActualAttributes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActualAttributes(){
        transform.position = new Vector3(startXPos, 0, startZPos);

        rb.velocity = new Vector3(startXVel, 0, startZVel);

        rb.mass = mass;

        transform.localScale = new Vector3(size, size, size);

        rend.material.color = color;
        rend.material.SetColor("_EmissionColor", color * emissionIntensity);
        rend.material.EnableKeyword("_EMISSION");
        
    }
    void CheckIfSelected(InputAction.CallbackContext context){
        ray = cam.ScreenPointToRay(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));

        if (Physics.Raycast(ray, out rayHit, 1000f)){
            if (rayHit.transform == transform){
                PlanetClicked();
            }
        }
    }

    void PlanetClicked(){
        planetUIManager.SetCurrentPlanet(gameObject);
    }
}
