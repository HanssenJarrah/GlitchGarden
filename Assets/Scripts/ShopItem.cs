using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an item that can be bought by the player from the shop.
/// </summary>
public class ShopItem : MonoBehaviour
{
    // Constants
    Color unselectedItemColour = new Color32(150, 150, 150, 255);

    // Configuration parameters
    [SerializeField] Defender defenderPrefab;

    /// <summary>
    /// Allows this item to be selected from the shop when the player clicks it with the mouse.
    /// This method is called by Unity when the player releases the mouse button while over this
    /// game object's collider.
    /// </summary>
    private void OnMouseUp()
    {
        var shopItems = FindObjectsOfType<ShopItem>();
        foreach (ShopItem item in shopItems)
        {
            item.GetComponent<SpriteRenderer>().color = unselectedItemColour;
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderPlacement>().SetSelectedDefender(defenderPrefab);
    }
}
