using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OmniSliderStartButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private float xSensitivity;
    [SerializeField]
    private float ySensitivity;
    [SerializeField]
    private TMP_InputField xInput;
    [SerializeField]
    private TMP_InputField yInput;
    [SerializeField]
    private PlanetUIManager uiManager;

    private float lastMouseXPos;
    private float currMouseXPos;
    private float mouseXDelta;
    private float lastMouseYPos;
    private float currMouseYPos;
    private float mouseYDelta;
    private PlayerControls controls;

    private Vector2 planetPos = new Vector2(0, 0);

    private bool dragging;
    private bool hovering;
    private RectTransform rectTransform;

    void Start()
    {
        controls = new PlayerControls();

        rectTransform = GetComponent<RectTransform>();

        hovering = false;

        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Disable();
        }
        else
        {
            controls.Planet_Creation.Enable();
            controls.Planet_Creation.Mouse_Down.performed += StartSliding;
            controls.Planet_Creation.Mouse_Down.canceled += StopSliding;
        }
    }

    public void OnMouseEnter()
    {
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Select.performed -= StartSliding;
            controls.Planet_Creation.Mouse_Down.canceled -= StopSliding;
            return;
        }
        hovering = true;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Select.performed -= StartSliding;
            controls.Planet_Creation.Mouse_Down.canceled -= StopSliding;
            return;
        }
        hovering = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void StartSliding(InputAction.CallbackContext context)
    {
        if (hovering)
            dragging = true;
    }
    void StopSliding(InputAction.CallbackContext context)
    {
        dragging = false;
    }

    public void Update()
    {
        lastMouseXPos = currMouseXPos;
        currMouseXPos = controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().x;

        mouseXDelta = (currMouseXPos - lastMouseXPos) * Time.deltaTime;

        lastMouseYPos = currMouseYPos;
        currMouseYPos = controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().y;

        mouseYDelta = (currMouseYPos - lastMouseYPos) * Time.deltaTime;


        GameObject planet = uiManager.planet;
        if (planet)
            planetPos = Camera.main.WorldToScreenPoint(planet.transform.position);

        rectTransform.position = planetPos;

        if (dragging)
        {
            // X Direction
            if (currMouseXPos <= 0)
            {
                Mouse.current.WarpCursorPosition(new Vector2(Screen.currentResolution.width - 10, controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().y));
                currMouseXPos = Screen.currentResolution.width - 10;
            }
            else if (currMouseXPos >= Screen.currentResolution.width)
            {
                Mouse.current.WarpCursorPosition(new Vector2(10, controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().y));
                currMouseXPos = 10;
            }
            else
            {
                xInput.text = "" + (float.Parse(xInput.text) + (mouseXDelta * xSensitivity));
                uiManager.UpdatePlanet();
            }


            // Y Direction
            if (currMouseYPos <= 0)
            {
                Mouse.current.WarpCursorPosition(new Vector2(controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().x, Screen.currentResolution.height - 10));
                currMouseYPos = Screen.currentResolution.height - 10;
            }
            else if (currMouseYPos >= Screen.currentResolution.height)
            {
                Mouse.current.WarpCursorPosition(new Vector2(controls.Planet_Creation.Mouse_Position.ReadValue<Vector2>().x, 10));
                currMouseYPos = 10;
            }
            else
            {
                yInput.text = "" + (float.Parse(yInput.text) + (mouseYDelta * ySensitivity));
                uiManager.UpdatePlanet();
            }
        }
    }
}