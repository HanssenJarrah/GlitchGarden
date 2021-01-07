using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float movementSpeed = 0f;

    private void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    public void StartWalking(float newSpeed)
    {
        movementSpeed = newSpeed;
        GetComponent<Collider2D>().enabled = true;
    }
}
