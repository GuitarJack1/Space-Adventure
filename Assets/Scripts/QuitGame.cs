using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    private PlayerControls controls;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        controls = new PlayerControls();
        controls.Quit_Application.Enable();

        controls.Quit_Application.Quit.performed += QuitGameMethod;
    }

    public void QuitGameMethod(InputAction.CallbackContext context)
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
}
