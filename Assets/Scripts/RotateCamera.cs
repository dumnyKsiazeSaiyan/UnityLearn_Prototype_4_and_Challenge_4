using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 60;
    private float horizontalAxis;

    //Rotation Speed Increased Over Time
    private float holdKey = 1;


    private void Update()
    {

        
        horizontalAxis = Input.GetAxis("Horizontal");
        transform.Rotate(rotationSpeed * horizontalAxis * Vector3.up * Time.deltaTime * RotationSpeedIncreasedOverTime());
    }


    float RotationSpeedIncreasedOverTime()
    {
        if (horizontalAxis > 0.5 || horizontalAxis < -0.5)
        {
            if (holdKey < 7)
            {
                holdKey += Time.deltaTime;
            }
        }

        else
        {
            holdKey -= 3 * Time.deltaTime;
            if (holdKey < 1)
            {
                holdKey = 1;
            }
        }

        return holdKey;
    }

}
