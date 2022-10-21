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
        //okresla w którym kierunku kula ma siê poruszaæ
        Vector3 moveDirection = (playerPosition.transform.position - transform.position).normalized;

        enemyRigidbody.AddForce(moveDirection * speed * Time.deltaTime);


        //jesli wróg spadnie zostaje zniszczony
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }

        
    }
}
