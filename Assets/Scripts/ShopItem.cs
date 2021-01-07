using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    Color unselectedItemColour = new Color32(150, 150, 150, 255);

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
