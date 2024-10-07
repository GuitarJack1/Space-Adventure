using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    private PlayerControls controls;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        controls = new PlayerControls();
    }

    void OnLevelWasLoaded(int index)
    {
        if (SceneManager.GetActiveScene().name == "Space Scene")
        {
            controls.Planet_Creation.Disable();
        }
    }
}
