using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPowerUps : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;
    private Quaternion quaterion;
    private Vector3 vRotation;

    private void Start()
    {


    }
    private void Update()
    {
        vRotation = Time.deltaTime * rotationSpeed * Vector3.up;

        quaterion = Quaternion.Euler(vRotation);

        transform.rotation *= quaterion;

    }
}
