using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;

    public float movementSpeed = 60;
    public float verticalAxis;

    public Vector3 rotateFromCamera;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }
    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        rotateFromCamera = focalPoint.transform.forward;
        verticalAxis = Input.GetAxis("Vertical");


        playerRigidbody.AddForce(Time.deltaTime * verticalAxis * movementSpeed * rotateFromCamera);

    }
}
