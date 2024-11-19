using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InformationPanelBehaviourSpace : MonoBehaviour
{
    private PlayerControls controls;

    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private GameObject pressIPanel;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Quit_Application.Enable();

        controls.Quit_Application.Toggle_Info_Panel.performed += ToggleInfoPanelMethod;

        infoPanel.SetActive(false);
        pressIPanel.SetActive(true);
    }

    public void ToggleInfoPanelMethod(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name == "Space Scene")
            infoPanel.SetActive(!infoPanel.activeSelf);
        pressIPanel.SetActive(!infoPanel.activeSelf);

    }
}
