using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for the generation of money over time from the trophy defender.
/// </summary>
public class StarSpawner : MonoBehaviour
{
    // Constants
    Vector3 offset = new Vector2(0f, 0.15f);

    // Configuration parameters
    [SerializeField] Star starPrefab;
    [SerializeField] int spawnWaitTime = 5;

    // State variables
    bool generateStars = true;

    /// <summary>
    /// Called by unity when this object is first instantiated as a co-routine. Controls the
    /// generation of stars over time which the player collects as money.
    /// </summary>
    /// <returns> Enumerated type yielded by the WaitForSeconds() method until the set time
    /// has passed.
    /// </returns>
    IEnumerator Start()
    {
        while (generateStars)
        {
            yield return new WaitForSeconds(spawnWaitTime);
            Instantiate(starPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
