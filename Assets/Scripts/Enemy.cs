using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject playerPosition;

    private Rigidbody enemyRigidbody;
    private float speed = 500.0f;


    private void Start()
    {
        playerPosition = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //okresla w kt�rym kierunku kula ma si� porusza�
        Vector3 moveDirection = (playerPosition.transform.position - transform.position).normalized;

        enemyRigidbody.AddForce(moveDirection * speed * Time.deltaTime);


        //jesli wr�g spadnie zostaje zniszczony
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }

        
    }
}
