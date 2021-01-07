using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] Star starPrefab;
    [SerializeField] int spawnWaitTime = 5;
    bool generateStars = true;

    IEnumerator Start()
    {
        while (generateStars)
        {
            yield return new WaitForSeconds(spawnWaitTime);
            Instantiate(starPrefab, transform.position, Quaternion.identity);
        }
    }
}
