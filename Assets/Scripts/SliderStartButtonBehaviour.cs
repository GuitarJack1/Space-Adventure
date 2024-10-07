using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SliderStartButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private PlanetUIManager uiManager;

    private float lastMouseXPos;
    private float currMouseXPos;
    private float mouseXDelta;
    private PlayerControls controls;

    private bool dragging;
    private bool hovering;

    void Start()
    {
        controls = new PlayerControls();

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

        if (dragging)
        {
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
                input.text = "" + (float.Parse(input.text) + (mouseXDelta * sensitivity));
                uiManager.UpdatePlanet();
            }
        }
    }
}