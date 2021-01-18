using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script attached to each defender game object specifying certain attributes such
/// as cost to place.
/// </summary>
public class Defender : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int price = 100;
    StarDisplay starDisplay;

    /// <summary>
    /// Called by Unity when the game object this script is attached to is first instantiated.
    /// Finds the game object that has the script controlling the star amount displayed to the player.
    /// </summary>
    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    /// <summary>
    /// Gets the cost in stars to place this new defender.
    /// </summary>
    /// <returns> The cost of this defender. </returns>
    public int GetStarCost()
    {
        return price;
    }

    public static implicit operator Defender(GameObject v)
    {
        throw new NotImplementedException();
    }
}
