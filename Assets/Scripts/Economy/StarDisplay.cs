using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script controls the display of how much money, ie. 'stars' the player currently has.
/// This includes the buying of new items using stars (provided the player has enough).
/// </summary>
public class StarDisplay : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int startingStars = 50;

    // State variables
    int currentStars;
    Text starText;

    /// <summary>
    /// This method is called by Unity when this game object is first instantiated.
    /// The method finds the text conponent on the same game object as this script that
    /// displays the current ammount of 'stars' to the player.
    /// </summary>
    private void Start()
    {
        starText = GetComponent<Text>();
        currentStars = startingStars;
        UpdateDisplayAmount();
    }

    /// <summary>
    /// Returns the current number of stars the player has to spend.
    /// </summary>
    /// <returns> The players current amount of stars. </returns>
    public int GetCurrentStars()
    {
        return currentStars;
    }

    /// <summary>
    /// Updates the visual display for the player of their current stars to match the
    /// number tracked internally.
    /// </summary>
    private void UpdateDisplayAmount()
    {
        starText.text = currentStars.ToString();
    }

    /// <summary>
    /// Adds the specified number of stars to the players total.
    /// </summary>
    /// <param name="amount"> The number of stars to add. </param>
    public void AddStars(int amount)
    {
        currentStars += amount;
        UpdateDisplayAmount();
    }

    /// <summary>
    /// Reduces the players stars by the specified amount if they currently have more than
    /// that number in the bank.
    /// </summary>
    /// <param name="amount"> Amount to reduce total stars by - generally the cost of something. </param>
    /// <returns> True if the player has enough stars. False otherwise. </returns>
    public bool SpendStars(int amount)
    {
        if(currentStars - amount < 0) { return false; }
        currentStars -= amount;
        UpdateDisplayAmount();
        return true;
    }
}
