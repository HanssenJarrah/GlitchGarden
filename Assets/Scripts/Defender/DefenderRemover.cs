using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script controlling the defender remover game object. This is the free item in the shop that
/// can destroy defenders when clicked.
/// </summary>
public class DefenderRemover : MonoBehaviour
{
    // Constants
    const float MAX_X = 7.5f;
    const float MIN_X = 0.5f;
    const float MAX_Y = 5.5f;
    const float MIN_Y = 0.5f;

    /// <summary>
    /// Called by Unity once per frame. This function sets the grid position of the remover - showing
    /// a visual preview of which defender would be destroyed. This Update method also detects if the
    /// remover has been moved outside the core game area. The update method detects if the remover
    /// has been unselected or if the mouse button has been clicked to destroy a defender.
    /// </summary>
    private void Update()
    {
        Vector2 mouseWorldPos = GetMousePos();
        Vector2 gridPos = SnapToGrid(mouseWorldPos);
        transform.position = gridPos;

        float x = mouseWorldPos.x;
        float y = mouseWorldPos.y;
        if((x <= MIN_X || x >= MAX_X) || (y <= MIN_Y || y >= MAX_Y))
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            DestroyTargetDefender();
        }
    }

    /// <summary>
    /// Destroys any defender under the current mouse position. A defender currently under the mouse
    /// position is detected using a raycast.
    /// </summary>
    private void DestroyTargetDefender()
    {
        Vector2 targetPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(targetPos);

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if (hit2D.collider != null)
        {
            GameObject hitObject = hit2D.collider.gameObject;
            if (hitObject.GetComponent<Defender>())
            {
                Destroy(hitObject);
            }
        }
    }

    /// <summary>
    /// Returns the mouse position converted to in game world units.
    /// </summary>
    /// <returns> Mouse position in world units. </returns>
    private Vector2 GetMousePos()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    /// <summary>
    /// Converts a world position to a grid snapped position.
    /// </summary>
    /// <param name="rawWorldPos"> World position to the converted to a grid snapped position. </param>
    /// <returns> Grid snapped position of the input. </returns>
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snappedX = Mathf.Round(rawWorldPos.x);
        float snappedY = Mathf.Round(rawWorldPos.y);
        return new Vector2(snappedX, snappedY);
    }
}
