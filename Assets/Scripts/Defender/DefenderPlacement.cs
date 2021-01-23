using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class allowing the placement of defenders within the play space.
/// </summary>
public class DefenderPlacement : MonoBehaviour
{
    // Configuration parameters
    Color32 cannotPlaceColour = new Color32(255, 35, 35, 128);
    Color32 normalPreviewColour = new Color32(128, 128, 128, 128);

    // State variables
    Defender defender;
    GameObject defenderPreview;
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    /// <summary>
    /// Called by unity once every frame.
    /// </summary>
    private void Update()
    {
        CheckSecondaryMouseButtonDown();
        ShowDefenderPreview();
    }

    /// <summary>
    /// Shows a preview of the defender that would be placed.
    /// </summary>
    private void ShowDefenderPreview()
    {
        if(defender != null && defenderPreview != null)
        {
            Vector2 mouseWorldPos = GetMousePos();
            Vector2 previewPos = SnapToGrid(mouseWorldPos);
            defenderPreview.transform.position = previewPos;

            SetPreviewColour();
        }
    }

    /// <summary>
    /// Set the colour of the preview as red or grey depending on if the currently selected defender
    /// can be afforded or not.
    /// </summary>
    private void SetPreviewColour()
    {
        int currentStars = starDisplay.GetCurrentStars();
        if (currentStars < defender.GetStarCost())
        {
            SpriteRenderer[] previewRenders = defenderPreview.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer renderer in previewRenders)
            {
                renderer.color = cannotPlaceColour;
            }
        } 
        else
        {
            SpriteRenderer[] previewRenders = defenderPreview.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer renderer in previewRenders)
            {
                renderer.color = normalPreviewColour;
            }
        }
    }

    /// <summary>
    /// Deselect defender to place if secondary mouse button clicked.
    /// </summary>
    private void CheckSecondaryMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FindObjectOfType<ShopItem>().DeselectAll();
            defender = null;
            Destroy(defenderPreview);
        }
    }

    /// <summary>
    /// Called by Unity when the mouse cursor enters the collider attached to this game object.
    /// Enables the preview of tower placement if a tower to place is currently selected.
    /// </summary>
    private void OnMouseEnter()
    {
        if (defender != null)
        {
            GameObject preview = defender.GetPreview();
            defenderPreview = Instantiate(preview, preview.transform.position, preview.transform.rotation);
            defenderPreview.SetActive(true);
        }
    }

    /// <summary>
    /// Called by unity when the mouse cursor exits the collider attached to this game object.
    /// Disables the preview of tower placement.
    /// </summary>
    private void OnMouseExit()
    {
        if (defenderPreview != null)
        {
            Destroy(defenderPreview);
        }
    }

    /// <summary>
    /// Called by Unity when the mouse button is released while over the collider attached to this game object.
    /// The collider attached to this game object defines the play space in which defenders may be placed.
    /// On call, this method will attempt to instantiate a defender at the clicked position.
    /// </summary>
    private void OnMouseUp()
    {
        Vector2 mouseWorldPos = GetMousePos();
        Vector2 placementPos = SnapToGrid(mouseWorldPos);
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
    private Vector2 GetMousePos()
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
