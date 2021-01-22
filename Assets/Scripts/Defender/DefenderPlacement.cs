using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class allowing the placement of defenders within the play space.
/// </summary>
public class DefenderPlacement : MonoBehaviour
{
    // State variables
    Defender defender;

    /// <summary>
    /// Called by Unity when the mouse button is released while over the collider attached to this game object.
    /// The collider attached to this game object defines the play space in which defenders may be placed.
    /// On call, this method will attempt to instantiate a defender at the clicked position.
    /// </summary>
    private void OnMouseUp()
    {
        Vector2 clickWorldPos = GetPosClicked();
        Vector2 placementPos = SnapToGrid(clickWorldPos);
        AttemptDefenderPlacement(placementPos);
    }

    /// <summary>
    /// Sets the type of defender to be placed on mouse click.
    /// </summary>
    /// <param name="selectedDefender"> Type of defender to be set. </param>
    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    /// <summary>
    /// Finds the current position of the players mouse and converts it to a position in game world space.
    /// </summary>
    /// <returns> The players mouse position in game world space. </returns>
    private Vector2 GetPosClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    /// <summary>
    /// Takes a raw game world position and converts it to a Unity grid snapped position.
    /// </summary>
    /// <param name="rawWorldPos"> The raw world position. </param>
    /// <returns> The grid snapped position. </returns>
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snappedX = Mathf.Round(rawWorldPos.x);
        float snappedY = Mathf.Round(rawWorldPos.y);
        return new Vector2(snappedX, snappedY);
    }

    /// <summary>
    /// Attempts to place a new defender given the player has enough money to do so.
    /// </summary>
    /// <param name="placementPos"> Grid snapped position at which to place the defender. </param>
    private void AttemptDefenderPlacement(Vector2 placementPos)
    {
        if(defender == null) { return; }    // If no defender is selected

        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (starDisplay.SpendStars(defenderCost))
        {
            PlaceDefender(placementPos);
        }
    }

    /// <summary>
    /// Instantiates a new defender at the specified position in the play space.
    /// </summary>
    /// <param name="atPosition"> Grid snapped position at which to place the defender. </param>
    private void PlaceDefender(Vector2 atPosition)
    {
        Instantiate(defender, atPosition, Quaternion.identity);
    }
}
