using UnityEngine;

public class SimCameraMovement : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed;

    private Vector3 startPos;

    public void Start()
    {
        startPos = transform.position;
    }
    public void MoveCamera(Vector3 inputVector)
    {
        transform.position += inputVector.normalized * cameraSpeed;
    }
    public void ResetCamera()
    {
        transform.position = startPos;
    }
}
