using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    bool moveStar = false;
    float speed = 10f;
    int starsToAdd = 50;
    Vector2 targetPos;
    
    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;

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
        }
    }

    private void OnMouseOver()
    {
        FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
        Destroy(gameObject);
    }

    public void MoveStar()
    {
        moveStar = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
