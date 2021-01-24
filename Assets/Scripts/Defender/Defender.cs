using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Script attached to each defender game object specifying certain attributes such
/// as cost to place.
/// </summary>
public class Defender : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int price = 100;
    [SerializeField] GameObject placementPreview;

    /// <summary>
    /// Gets the cost in stars to place this new defender.
    /// </summary>
    /// <returns> The cost of this defender. </returns>
    public int GetStarCost()
    {
        return price;
    }

    /// <summary>
    /// Returns the object intended as the visual preview when placing this defender.
    /// </summary>
    /// <returns></returns>
    public GameObject GetPreview()
    {
        return placementPreview;
    }
}
