using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Defines an item that can be bought by the player from the shop.
/// </summary>
public class ShopItem : MonoBehaviour
{
    // Constants
    Color[] unselectedItemColour; // = new Color32(150, 150, 150, 255);

    // Configuration parameters
    [SerializeField] Defender defenderPrefab;

    /// <summary>
    /// Called by unity when the game object this script is attached to is first instantiated.
    /// Labels each shop item with the appropriate cost, and saves what colour it should be when
    /// unselected.
    /// </summary>
    private void Start()
    {
        LabelItemWithCost();

        // Set the unselected colour for each shop item
        var shopItems = FindObjectsOfType<ShopItem>();
        unselectedItemColour = new Color[shopItems.Length];
        for (int i = 0; i < shopItems.Length; i++)
        {
            unselectedItemColour[i] = shopItems[i].GetComponent<SpriteRenderer>().color;
        }
    }

    /// <summary>
    /// Labels the shop item with its cost to buy.
    /// </summary>
    private void LabelItemWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) { return; }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    /// <summary>
    /// Allows this item to be selected from the shop when the player clicks it with the mouse.
    /// This method is called by Unity when the player releases the mouse button while over this
    /// game object's collider.
    /// </summary>
    private void OnMouseUp()
    {
        var shopItems = FindObjectsOfType<ShopItem>();
        for (int i = 0; i < shopItems.Length; i++)
        {
            // Grey out all shop icons
            shopItems[i].GetComponent<SpriteRenderer>().color = unselectedItemColour[i];
        }
        // Make selected shop item full colour
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderPlacement>().SetSelectedDefender(defenderPrefab);
    }
}