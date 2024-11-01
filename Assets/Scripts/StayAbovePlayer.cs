using UnityEngine;

public class StayAbovePlayer : MonoBehaviour
{
    [SerializeField]
    private Transform spaceshipT;
    [SerializeField]
    private float hoverHeight;
    [SerializeField]
    private bool rotateWithPlayer;

    private Transform thisTransform;
    private Transform thisRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        thisRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisTransform != null)
        {
            thisTransform.position = new Vector3(spaceshipT.transform.position.x, spaceshipT.transform.position.y + hoverHeight, spaceshipT.transform.position.z);
        }
        else
        {
            thisRectTransform.position = new Vector3(spaceshipT.transform.position.x, spaceshipT.transform.position.y + hoverHeight, spaceshipT.transform.position.z);
        }

        if (rotateWithPlayer)
        {
            if (thisTransform != null)
            {
                thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, spaceshipT.eulerAngles.y, thisTransform.eulerAngles.z);
            }
            else
            {
                thisRectTransform.eulerAngles = new Vector3(thisRectTransform.eulerAngles.x, spaceshipT.eulerAngles.y, thisRectTransform.eulerAngles.z);
            }
        }
    }
}
