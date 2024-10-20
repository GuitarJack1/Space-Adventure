using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateSpaceshipUI : MonoBehaviour
{
    [SerializeField]
    private Transform spaceshipT;
    [SerializeField]
    private Rigidbody spaceshipRB;
    [SerializeField]
    private RectTransform needleRotationPoint;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxShake;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float speed = spaceshipRB.velocity.magnitude;
        float needleAngle = 90 - ((speed / maxSpeed) * 180);

        needleAngle += UnityEngine.Random.Range(-((speed / maxSpeed) * maxShake), ((speed / maxSpeed) * maxShake));

        needleRotationPoint.eulerAngles = new Vector3(0, 0, needleAngle);
    }
}
