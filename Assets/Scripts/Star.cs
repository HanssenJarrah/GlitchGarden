using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Star : MonoBehaviour
{
    bool moveStar = false;
    float speed = 10f;
    int starsToAdd = 50;
    Vector2 targetPos;
    Vector2 finalTargetPos = new Vector2(9.94f, 5.93f);
    BoxCollider2D colliderComponent;
    
    private void Start()
    {
        colliderComponent = GetComponent<BoxCollider2D>();
        colliderComponent.enabled = false;

        float xPos = Random.Range(3f, 9f);
        float yPos = Random.Range(1f, 5f);
        targetPos = new Vector2(xPos, yPos);
    }

    private void Update()
    {
        if (moveStar)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.001f)
            {
                moveStar = false;
            }

            if (Vector3.Distance(transform.position, finalTargetPos) < 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseOver()
    {
        FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
        colliderComponent.enabled = false;
        moveStar = true;
        targetPos = finalTargetPos;
    }

    public void MoveStar()
    {
        moveStar = true;
        colliderComponent.enabled = true;
    }
}
