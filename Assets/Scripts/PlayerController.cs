using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public float movementSpeed = 60.0f;
    public float verticalAxis;

    public Vector3 rotateFromCamera;

    public bool hasPowerUp;
    private float powerUpStrength = 700.0f;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }
    private void Update()
    {
        PlayerMovement();
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }
    void PlayerMovement()
    {
        rotateFromCamera = focalPoint.transform.forward;
        verticalAxis = Input.GetAxis("Vertical");


        playerRigidbody.AddForce(Time.deltaTime * verticalAxis * movementSpeed * rotateFromCamera);

        //Powerup Indicator 
        powerupIndicator.transform.position = transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")  && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(Time.deltaTime * powerUpStrength * awayFromPlayer, ForceMode.Impulse);
            
        }
    }
}
